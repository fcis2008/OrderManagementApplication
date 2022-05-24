using OrderManagement.Core.Models;

namespace OrderManagement.Core.Services
{
    public interface IStateService
    {
        /// <summary>
        /// Return all states
        /// </summary>
        /// <returns>state</returns>
        
        Task<IEnumerable<State>>  GetAllStatesAsync();
    }
}
