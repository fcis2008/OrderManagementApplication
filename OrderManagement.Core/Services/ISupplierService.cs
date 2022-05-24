using OrderManagement.Core.Models;

namespace OrderManagement.Core.Services
{
    public interface ISupplierService
    {
        /// <summary>
        /// Return all suppliers including records marked as disabled
        /// </summary>
        /// <returns>Supplier</returns>
        Task<IEnumerable<Supplier>> GetAllSuppliersAsync();

        /// <summary>
        /// Return list of suppliers which are not marked as deleted.
        /// </summary>
        /// <returns>Supplier</returns>
        Task<ICollection<Supplier>> GetActiveSuppliersAsync();

        /// <summary>
        /// Return list of suppliers which are marked as deleted
        /// </summary>
        /// <returns>Supplier</returns>
        Task<ICollection<Supplier>> GetDisabledSuppliersAsync();

        /// <summary>
        /// Return a supplier record
        /// </summary>
        /// <param name="SupplierID"></param>
        /// <returns>Supplier</returns>
        Task<Supplier?> GetSupplierByIDAsync(int supplierID);

        /// <summary>
        /// Return True/False if record exist
        /// </summary>
        /// <param name="SupplierID"></param>
        /// <returns>bool</returns>
        Task<bool> SupplierExistAsync(int supplierID);

        /// Add a new record for supplier
        /// </summary>
        /// <param name="supplier"></param>
        Task<Supplier> AddSupplierAsync(Supplier supplier);

        /// <summary>
        /// Update a record in db
        /// </summary>
        /// <param name="supplier"></param>
        /// <returns>bool</returns>
        Task UpdateSupplierAsync(Supplier supplierToBeUpdated, Supplier supplier);

        /// <summary>
        /// Update a record as disabled
        /// </summary>
        /// <param name="SupplierID"></param>
        /// <returns>bool</returns>
        Task SoftDeleteSupplierAsync(int supplierID);
    }
}
