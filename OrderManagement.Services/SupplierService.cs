using OrderManagement.Core;
using OrderManagement.Core.Models;
using OrderManagement.Core.Services;

namespace OrderManagement.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly IUnitOfWork unitOfWork;

        public SupplierService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Supplier> AddSupplierAsync(Supplier supplier)
        {
            await unitOfWork.Suppliers.AddSupplierAsync(supplier);
            await unitOfWork.CommitAsync();
            return supplier;
        }

        public async Task<ICollection<Supplier>> GetActiveSuppliersAsync()
        {
           return await unitOfWork.Suppliers.GetActiveSuppliersAsync();
        }

        public async Task<IEnumerable<Supplier>> GetAllSuppliersAsync()
        {
           return await unitOfWork.Suppliers.GetAllSuppliersAsync();
        }

        public async Task<ICollection<Supplier>> GetDisabledSuppliersAsync()
        {
            return await unitOfWork.Suppliers.GetDisabledSuppliersAsync();
        }

        public async Task<Supplier?> GetSupplierByIDAsync(int supplierID)
        {
            return await unitOfWork.Suppliers.GetSupplierByIDAsync(supplierID);
        }

        public async Task SoftDeleteSupplierAsync(int supplierID)
        {
            await unitOfWork.Suppliers.SoftDeleteSupplierAsync(supplierID);
            await unitOfWork.CommitAsync();
        }

        public async Task<bool> SupplierExistAsync(int supplierID)
        {
            return await unitOfWork.Suppliers.SupplierExistAsync(supplierID);
        }

        public async Task UpdateSupplierAsync(Supplier supplierToBeUpdated, Supplier supplier)
        {
            supplierToBeUpdated.Name = supplier.Name;
            supplierToBeUpdated.AddressLine1 = supplier.AddressLine1;
            supplierToBeUpdated.AddressLine2 = supplier.AddressLine2;
            supplierToBeUpdated.City = supplier.City;
            supplierToBeUpdated.PostalCode = supplier.PostalCode;
            supplierToBeUpdated.FKStateID = supplier.FKStateID;
            supplierToBeUpdated.IsActive = supplier.IsActive;

            await unitOfWork.CommitAsync();
        }
    }
}
