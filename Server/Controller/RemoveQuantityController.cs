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
    public class RemoveQuantityController : AbstractController
    {
        private  string employeeName;
        private  int itemId;
        private  int quantityToRemove;
        private double itemPrice;

        public RemoveQuantityController(string employeeName, int itemId, int quantityToRemove,
            AbstractPresenter presenter): base (new DataGatewayFacade(), presenter)
        {
            this.employeeName = employeeName;
            this.itemId = itemId;
            this.quantityToRemove = quantityToRemove;
            
        }

        public override List<TransactionLogEntry> ExecutePersonalUsage()
        {
            throw new NotImplementedException();
        }

        public override DTO ExecuteUseCase()
        {
            return new TakeQuantityItem(employeeName,itemId,quantityToRemove,itemPrice,gatewayFacade).Execute();
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
