﻿using GloboTicket.TicketManagement.Application.Contracts.Identity;
using GloboTicket.TicketManagement.Application.Models.Authentication;
using GloboTicket.TicketManagement.Identity.Models;
using GloboTicket.TicketManagement.Identity.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Text;

namespace GloboTicket.TicketManagement.Identity
{
    public static class IdentityServiceExtensions
    {
        public static void AddIdentityServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));

            var dbProvider = configuration.GetValue<string>("dbProvider");
            switch (dbProvider)
            {
                case "MSSQL":
                    services.AddDbContext<GloboTicketIdentityDbContext>(
                        options => options.UseSqlServer(configuration.GetConnectionString("GloboTicketIdentityConnectionString"),
                        b => b.MigrationsAssembly(typeof(GloboTicketIdentityDbContext).Assembly.FullName)));
                    break;
                case "PGSQL":
                    services.AddDbContext<GloboTicketIdentityDbContext>(
                        options => options.UseNpgsql(configuration.GetConnectionString("GloboTicketIdentityConnectionString"),
                        b => b.MigrationsAssembly(typeof(GloboTicketIdentityDbContext).Assembly.FullName)));
                    break;
                case "MySQL":
                    services.AddDbContext<GloboTicketIdentityDbContext>(
                         options => options.UseMySql(configuration.GetConnectionString("GloboTicketIdentityConnectionString"),
            new MySqlServerVersion(new Version(8, 0,11)),
                         b => b.MigrationsAssembly(typeof(GloboTicketIdentityDbContext).Assembly.FullName)));
                    break;
                default:
                    break;
            }

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<GloboTicketIdentityDbContext>().AddDefaultTokenProviders();

            services.AddTransient<IAuthenticationService, AuthenticationService>();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(o =>
                {
                    o.RequireHttpsMetadata = false;
                    o.SaveToken = false;
                    o.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero,
                        ValidIssuer = configuration["JwtSettings:Issuer"],
                        ValidAudience = configuration["JwtSettings:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:Key"]))
                    };

                    o.Events = new JwtBearerEvents()
                    {
                        OnAuthenticationFailed = c =>
                        {
                            c.NoResult();
                            c.Response.StatusCode = 500;
                            c.Response.ContentType = "text/plain";
                            return c.Response.WriteAsync(c.Exception.ToString());
                        },
                        OnChallenge = context =>
                        {
                            context.HandleResponse();
                            context.Response.StatusCode = 401;
                            context.Response.ContentType = "application/json";
                            var result = JsonConvert.SerializeObject("401 Not authorized");
                            return context.Response.WriteAsync(result);
                        },
                        OnForbidden = context =>
                        {
                            context.Response.StatusCode = 403;
                            context.Response.ContentType = "application/json";
                            var result = JsonConvert.SerializeObject("403 Not authorized");
                            return context.Response.WriteAsync(result);
                        },
                    };
                });
        }
    }
}
