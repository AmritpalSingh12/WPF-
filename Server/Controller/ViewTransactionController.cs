using Server.DataGateway.MySql;
using Server.DTOs;
using Server.Entities;
using Server.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Controller
{
    public class ViewTransactionController : AbstractController
    {
        public ViewTransactionController(
            AbstractPresenter presenter): base(new DataGatewayFacade(), presenter)
                {

        }

        public override List<TransactionLogEntry> ExecutePersonalUsage()
        {
            throw new NotImplementedException();
        }

        public override DTO ExecuteUseCase()
        {
            return new ViewTransaction(gatewayFacade).Execute();
        }

        public override List<TransactionLogEntry> ExecuteUseCaseFinancial()
        {
            throw new NotImplementedException();
        }

        public override Dictionary<int, ItemDTO> ExecuteUseCaseGrid()
        {
            throw new NotImplementedException();
        }

        public override List<TransactionLogEntry> TransactionLogs()
        {
            return new ViewTransaction(gatewayFacade).ExecuteTransaction();
        }

    }
}
