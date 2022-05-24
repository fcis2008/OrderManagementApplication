using OrderManagement.Core.Models;

namespace OrderManagement.Core.Repositories
{
    public interface IStateRepository
    {
        /// <summary>
        /// Return all states
        /// </summary>
        /// <returns>state</returns>
        Task<IEnumerable<State>> GetAllStatesAsync();
    }
}
