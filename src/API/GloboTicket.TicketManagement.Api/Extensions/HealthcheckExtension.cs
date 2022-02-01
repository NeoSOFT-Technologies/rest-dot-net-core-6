using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace GloboTicket.TicketManagement.Api.Extensions
{
    public static class HealthcheckExtensionRegistration
    {
        public static IServiceCollection AddHealthcheckExtensionService(this IServiceCollection services, IConfiguration configuration)
        {
            var dbProvider = configuration.GetValue<string>("dbProvider");
            switch (dbProvider)
            {
                case "MSSQL":
                    services.AddHealthChecks()
                        .AddSqlServer(configuration["ConnectionStringsMSSQL:GloboTicketIdentityConnectionString"], tags: new[] {
                            "db",
                            "all"})
                        .AddUrlGroup(new Uri(configuration["API:WeatertherInfo"]), tags: new[] {
                            "testdemoUrl",
                            "all"
                        });
                    services.AddHealthChecksUI(opt =>
                    {
                        opt.SetEvaluationTimeInSeconds(15); //time in seconds between check
                        opt.MaximumHistoryEntriesPerEndpoint(60); //maximum history of checks
                        opt.SetApiMaxActiveRequests(1); //api requests concurrency
                        opt.AddHealthCheckEndpoint("API", "/healthz"); //map health check api
                    }).AddSqlServerStorage(configuration["ConnectionStringsMSSQL:GloboTicketHealthCheckConnectionString"]);
                    break;
                case "PGSQL":
                    services.AddHealthChecks()
                        .AddNpgSql(configuration["ConnectionStringsPGSQL:GloboTicketIdentityConnectionString"], tags: new[] {
                            "db",
                            "all"})
                        .AddUrlGroup(new Uri(configuration["API:WeatertherInfo"]), tags: new[] {
                            "testdemoUrl",
                            "all"
                        });
                    services.AddHealthChecksUI(opt =>
                    {
                        opt.SetEvaluationTimeInSeconds(15); //time in seconds between check
                        opt.MaximumHistoryEntriesPerEndpoint(60); //maximum history of checks
                        opt.SetApiMaxActiveRequests(1); //api requests concurrency
                        opt.AddHealthCheckEndpoint("API", "/healthz"); //map health check api
                    }).AddPostgreSqlStorage(configuration["ConnectionStringsPGSQL:GloboTicketHealthCheckConnectionString"]);
                    break;
                case "MySQL":
                    services.AddHealthChecks()
                        .AddMySql(configuration["ConnectionStringsMySQL:GloboTicketIdentityConnectionString"], tags: new[] {
                            "db",
                            "all"})
                        .AddUrlGroup(new Uri(configuration["API:WeatertherInfo"]), tags: new[] {
                            "testdemoUrl",
                            "all"
                        });
                    services.AddHealthChecksUI(opt =>
                    {
                        opt.SetEvaluationTimeInSeconds(15); //time in seconds between check
                        opt.MaximumHistoryEntriesPerEndpoint(60); //maximum history of checks
                        opt.SetApiMaxActiveRequests(1); //api requests concurrency
                        opt.AddHealthCheckEndpoint("API", "/healthz"); //map health check api
                    }).AddMySqlStorage(configuration["ConnectionStringsMySQL:GloboTicketHealthCheckConnectionString"]);
                    break;
                case "SQLite":
                    services.AddHealthChecks()
                        .AddSqlite(configuration["ConnectionStringsSQLite:GloboTicketIdentityConnectionString"], tags: new[] {
                            "db",
                            "all"})
                        .AddUrlGroup(new Uri(configuration["API:WeatertherInfo"]), tags: new[] {
                            "testdemoUrl",
                            "all"
                        });
                    services.AddHealthChecksUI(opt =>
                    {
                        opt.SetEvaluationTimeInSeconds(15); //time in seconds between check
                        opt.MaximumHistoryEntriesPerEndpoint(60); //maximum history of checks
                        opt.SetApiMaxActiveRequests(1); //api requests concurrency
                        opt.AddHealthCheckEndpoint("API", "/healthz"); //map health check api
                    }).AddSqliteStorage(configuration["ConnectionStringsSQLite:GloboTicketHealthCheckConnectionString"]);
                    break;
                default:
                    break;
            }

            return services;
        }
    }
}
