﻿using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using GloboTicket.TicketManagement.Domain.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace GloboTicket.TicketManagement.Persistence.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {

        private readonly ILogger _logger;
        public CategoryRepository(GloboTicketDbContext dbContext, ILogger<Category> logger) : base(dbContext, logger)
        {
            _logger = logger;
        }

        public async Task<List<Category>> GetCategoriesWithEvents(bool includePassedEvents)
        {
            _logger.LogInformation("GetCategoriesWithEvents Initiated");
            var allCategories = await _dbContext.Set<Category>().Include(x => x.Events).ToListAsync();
            if(!includePassedEvents)
            {
                allCategories.ForEach(p => p.Events.ToList().RemoveAll(c => c.Date < DateTime.Today));
            }
            _logger.LogInformation("GetCategoriesWithEvents Completed");
            return allCategories;
        }

        public async Task<Category> AddCategory(Category category)
        {
            //var categoryId = Guid.NewGuid();
            //List<SqlParameter> parms = new List<SqlParameter>
            //    {
            //        // Create parameter(s)
            //        new SqlParameter { ParameterName = "@CategoryId", Value = categoryId },
            //        new SqlParameter { ParameterName = "@Name", Value = category.Name },
            //    };
            //await StoredProcedureCommandAsync("CreateCategory", parms.ToArray());
            //category = await GetByIdAsync(categoryId);
            return category;
        }
    }
}
