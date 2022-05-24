using Microsoft.EntityFrameworkCore;
using OrderManagement.Core.Models;
using OrderManagement.Core.Repositories;

namespace OrderManagement.Data.Repository
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly OrderManagementContext DbContext;

        public SupplierRepository(OrderManagementContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task AddSupplierAsync(Supplier supplier)
        {
            await DbContext.Suppliers.AddAsync(supplier);
        }

        public async Task<IEnumerable<Supplier>> GetAllSuppliersAsync()
        {
            return await DbContext.Suppliers.Include(S => S.State).AsNoTracking().ToListAsync();
        }

        public async Task<ICollection<Supplier>> GetDisabledSuppliersAsync()
        {
            return await DbContext.Suppliers.Where(S => !S.IsActive).Include(S => S.State).AsNoTracking().ToListAsync();
        }

        public async Task<Supplier?> GetSupplierByIDAsync(int supplierID)
        {
            return await DbContext.Suppliers.Where(S => S.ID == supplierID).Include(S => S.State).FirstOrDefaultAsync();
        }

        public async Task<ICollection<Supplier>> GetActiveSuppliersAsync()
        {
            return await DbContext.Suppliers.Where(S => S.IsActive).Include(S => S.State).AsNoTracking().ToListAsync();
        }

        public async Task SoftDeleteSupplierAsync(int supplierID)
        {
            var exisitngSupplier = await GetSupplierByIDAsync(supplierID);

            if (exisitngSupplier != null)
                exisitngSupplier.IsActive = false;
        }

        public async Task<bool> SupplierExistAsync(int SupplierID)
        {
            return await DbContext.Suppliers.AnyAsync(S => S.ID == SupplierID);
        }
    }
}
