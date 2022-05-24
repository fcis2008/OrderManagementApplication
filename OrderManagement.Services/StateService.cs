using OrderManagement.Core;
using OrderManagement.Core.Models;
using OrderManagement.Core.Services;

namespace OrderManagement.Services
{
    public class StateService : IStateService
    {
        private readonly IUnitOfWork unitOfWork;
        public StateService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<State>> GetAllStatesAsync()
        {
            return await unitOfWork.States.GetAllStatesAsync();
        }
    }
}