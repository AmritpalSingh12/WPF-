using Server.DataGateway.MySql;
using Server.DTOs;
using Server.Entities;
using Server.UseCases;
using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Controller
{
    public class InitailiseDatabaseController : AbstractController
    {
        public InitailiseDatabaseController(
            AbstractPresenter presenter) : base(new DataGatewayFacade(), presenter)
        {

        }

        public override List<TransactionLogEntry> ExecutePersonalUsage()
        {
            throw new NotImplementedException();
        }

        public override DTO ExecuteUseCase()
        {
            return new InitialiseDatabase(gatewayFacade).Execute();
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
            throw new NotImplementedException();
        }
    }
}
