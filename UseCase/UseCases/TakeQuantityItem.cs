using Assignment.DTOs;
using Assignment.Library;
using Assignment.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.UseCases
{
    public  class TakeQuantityItem : AbstractUseCase
    {
        private readonly string employeeName;
        private readonly int itemId;
        private readonly int quantityToRemove;
        private readonly double itemPrice;

        public TakeQuantityItem(string employeeName, int itemId, int quantityToRemove, double itemPrice, IDataGatewayFacade gatewayFacade) : base(gatewayFacade)   
        {
            this.employeeName = employeeName;
            this.itemId = itemId;
            this.quantityToRemove = quantityToRemove;
            this.itemPrice = itemPrice;
        }

        public override DTO Execute()
        {
            try
            {
                EmployeeConverter employeeConverter = new EmployeeConverter();
                EmployeeDTO EmpName = employeeConverter.ConvertToDTO(gatewayFacade.FindEmployee(this.employeeName));
                if (EmpName == null)
                {
                    return new MassageDTO("ERROR: Employee not found");
                }
                
               
                Item item = gatewayFacade.FindItem(itemId);
                if (item == null)
                {
                    return new MassageDTO("ERROR: Item not found");
                }

               

                item.RemoveQuantity(quantityToRemove);
                gatewayFacade.RemoveQuantity(item);
                Console.WriteLine(
                    "{0} has removed {1} of Item ID: {2} on {3}",
                    employeeName,
                    quantityToRemove,
                    itemId,
                    DateTime.Now.ToString("dd/MM/yyyy"));

                gatewayFacade.AddTransactionLog(
                    new TransactionLogEntry("Quantity Removed", item.ID, item.Name, -1, quantityToRemove, employeeName, DateTime.Now));
                return new MassageDTO("Quantity Removed");
            }
            catch (Exception e)
            {
                return new MassageDTO(e.Message);
            }
        }

        public override Dictionary<int, ItemDTO> ExecuteGrid()
        {
            throw new NotImplementedException();
        }
    }
}
