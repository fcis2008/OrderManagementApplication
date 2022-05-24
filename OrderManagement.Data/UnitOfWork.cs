using OrderManagement.Core;
using OrderManagement.Core.Repositories;
using OrderManagement.Data.Repository;

namespace OrderManagement.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly OrderManagementContext orderManagementContext;

        public UnitOfWork(OrderManagementContext orderManagementContext)
        {
            this.orderManagementContext = orderManagementContext;
            States = new StateRepository(this.orderManagementContext);
            Suppliers = new SupplierRepository(this.orderManagementContext);
        }

        public IStateRepository States
        {
            get;
            private set;
        }    

        public ISupplierRepository Suppliers
        {
            get;
            private set;
        }

        public async Task<int> CommitAsync()
        {
            return await orderManagementContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            orderManagementContext.Dispose();
        }
    }
}
