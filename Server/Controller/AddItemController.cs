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
    public class AddItemController : AbstractController
    {
        private string employeeName;
        private int itemId;
        private string itemName;
        private int itemQuantity;
        private double itemPrice;
        private DateTime addeddate;

        public AddItemController(string employeeName, int itemId, string itemName, int itemQuantity, double itemPrice,
            AbstractPresenter presenter) : base(new DataGatewayFacade(), presenter)
        {
            this.employeeName = employeeName;
            this.itemId = itemId;
            this.itemName = itemName;
            this.itemQuantity = itemQuantity;
           
            this.itemPrice = itemPrice;
            
        }

        public override List<TransactionLogEntry> ExecutePersonalUsage()
        {
            throw new NotImplementedException();
        }

        public override DTO ExecuteUseCase()
        {
            return new AddItem(employeeName,itemPrice, itemId, itemName, itemQuantity, addeddate, gatewayFacade).Execute();
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
