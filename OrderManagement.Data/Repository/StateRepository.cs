using Microsoft.EntityFrameworkCore;
using OrderManagement.Core.Models;
using OrderManagement.Core.Repositories;

namespace OrderManagement.Data.Repository
{
    public class StateRepository : IStateRepository
    {
        private readonly OrderManagementContext DbContext;

        public StateRepository(OrderManagementContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task<IEnumerable<State>> GetAllStatesAsync()
        {
            return await DbContext.States.AsNoTracking().ToListAsync();
        }
    }
}
