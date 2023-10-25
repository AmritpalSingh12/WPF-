using Server.DTOs;

namespace Server.UseCases
{
    public abstract class AbstractUseCase
    {
        protected readonly IDataGatewayFacade gatewayFacade;

        protected AbstractUseCase(IDataGatewayFacade gatewayFacade)
        {
            this.gatewayFacade = gatewayFacade;
        }

        public abstract DTO Execute();
        public abstract Dictionary<int, ItemDTO> ExecuteGrid();
    }
}
