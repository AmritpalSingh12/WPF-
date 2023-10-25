using Server.DTOs;
using Server.Entities;
using Server.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.UseCases
{
    public class AddQuantity : AbstractUseCase
    {
        private readonly string employeeName;
        private readonly int itemId;
        private readonly int quantityToAdd;
        private readonly double itemPrice;


        public AddQuantity(string employeeName, int itemId, int quantityToAdd, double itemPrice, IDataGatewayFacade gatewayFacade) : base(gatewayFacade)    
        {
            this.employeeName = employeeName;
            this.itemId = itemId;
            this.quantityToAdd = quantityToAdd;
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

                
                if (itemPrice < 0)
                {
                    return new MassageDTO("ERROR: Price below 0");
                }

                item.AddQuantity(quantityToAdd);
                gatewayFacade.AddQuantity(item);
                Console.WriteLine(
                    "{0} items have been added to Item ID: {1} on {2}",
                    quantityToAdd,
                    itemId,
                    DateTime.Now.ToString("dd/MM/yyyy"));

                gatewayFacade.AddTransactionLog(
                    new TransactionLogEntry("Quantity Added", item.ID, item.Name, itemPrice, quantityToAdd, employeeName, DateTime.Now));

                return new MassageDTO("Quantity Added");
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





