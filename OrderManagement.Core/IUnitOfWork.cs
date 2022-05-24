using OrderManagement.Core.Repositories;

namespace OrderManagement.Core
{
    public interface IUnitOfWork : IDisposable
    {
        ISupplierRepository Suppliers { get; }
        IStateRepository States { get; }
        Task<int> CommitAsync();
    }
}
