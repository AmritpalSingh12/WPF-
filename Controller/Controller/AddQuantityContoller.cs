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
    public class AddQuantityContoller : AbstractController
    {
        private  string employeeName;
        private  int itemId;
        private  int quantityToAdd;
        private double itemPrice;

        public AddQuantityContoller(string employeeName, int itemId, int quantityToAdd, double itemPrice,
            AbstractPresenter presenter) : base (new DataGatewayFacade(), presenter)
        {
            this.employeeName = employeeName;
            this.itemId = itemId;
            this.quantityToAdd = quantityToAdd;
            this.itemPrice = itemPrice;
        }

        public override List<TransactionLogEntry> ExecutePersonalUsage()
        {
            throw new NotImplementedException();
        }

        public override DTO ExecuteUseCase()
        {
            return new AddQuantity(employeeName,itemId,quantityToAdd,itemPrice, gatewayFacade).Execute();
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
