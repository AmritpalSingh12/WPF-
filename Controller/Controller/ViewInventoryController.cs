using Assignment.DataGateway.MySql;
using Assignment.DTOs;
using Assignment.Library;
using Assignment.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.UseCases;

namespace Controller.Controller
{
    public class ViewInventoryController : AbstractController
    {

        public ViewInventoryController(
            AbstractPresenter presenter) : base(new DataGatewayFacade(), presenter)
        {
        }

        public override List<TransactionLogEntry> ExecutePersonalUsage()
        {
            throw new NotImplementedException();
        }

        public override DTO ExecuteUseCase()
        {
            return new ViewInventory(gatewayFacade).Execute();
        }

        public override List<TransactionLogEntry> ExecuteUseCaseFinancial()
        {
            throw new NotImplementedException();
        }

        public override Dictionary<int, ItemDTO> ExecuteUseCaseGrid()
        {
            Dictionary<int, ItemDTO> items = new ViewInventory(gatewayFacade).ExecuteGrid();
            return items;
        }

        public override List<TransactionLogEntry> TransactionLogs()
        {
            throw new NotImplementedException();
        }
    }
}
