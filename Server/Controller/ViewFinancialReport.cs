using Server.DataGateway.MySql;
using Server.DTOs;
using Server.Entities;
using Server.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.UseCases;

namespace Server.Controller
{
    public class ViewFinancialReportController : AbstractController
    {
        public ViewFinancialReportController(
            AbstractPresenter presenter) : base (new DataGatewayFacade(), presenter)
        {

        }
        public override DTO ExecuteUseCase()
        {
            return new ViewFinancialReport(gatewayFacade).Execute();
        }

        public override Dictionary<int, ItemDTO> ExecuteUseCaseGrid()
        {
            Dictionary<int, ItemDTO> items = new ViewInventory(gatewayFacade).ExecuteGrid();
            return items;
        }

        public override List<TransactionLogEntry> ExecuteUseCaseFinancial()
        {
           var result = new ViewFinancialReport(gatewayFacade).ViewFinancilGrid();
            return result;
        }

        public override List<TransactionLogEntry> ExecutePersonalUsage()
        {
            throw new NotImplementedException();
        }

        public override List<TransactionLogEntry> TransactionLogs()
        {
            throw new NotImplementedException();
        }
    }
}
