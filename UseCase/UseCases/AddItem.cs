
using Assignment.DTOs;
using Assignment.Library;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.UseCases
{
    public class AddItem : AbstractUseCase
    {
       private readonly string employeeName;
        private readonly double itemPrice;
        private readonly int itemId;
        private readonly string itemName;
        private readonly int itemQuantity;
        private readonly DateTime addeddate;

        public AddItem(string employeeName, double itemPrice, int itemId, string itemName, int itemQuantity, DateTime addeddate, IDataGatewayFacade gatewayFacade) : base(gatewayFacade)
        {
            this.employeeName = employeeName;
            this.itemPrice = itemPrice;
            this.itemId = itemId;
            this.itemName = itemName;
            this.itemQuantity = itemQuantity;
            this.addeddate = DateTime.Now;
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

            
                if (itemPrice < 0)
                {
                    throw new Exception("ERROR: Price below 0");
                }
                DateTime Addeddate = DateTime.Now;
                Item item = new Item(itemId, itemName, itemQuantity, DateTime.Now);
                gatewayFacade.AddItem(item);
                gatewayFacade.AddTransactionLog(
                    new TransactionLogEntry("Item Added", itemId, itemName, itemPrice, itemQuantity, employeeName, DateTime.Now));

               


                return new MassageDTO("Item Added");




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
