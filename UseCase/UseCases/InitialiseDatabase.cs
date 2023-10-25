using Assignment.DTOs;
using Assignment.Library;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.UseCases
{
    public class InitialiseDatabase : AbstractUseCase
    {

        public InitialiseDatabase(IDataGatewayFacade gatewayFacade) : base(gatewayFacade)
        {

        }

        public override DTO Execute()
        {

            gatewayFacade.InitialiseMySqlDatabase();

            gatewayFacade.AddEmployee(new Employee("Graham"));
            gatewayFacade.AddEmployee(new Employee("Phil"));
            gatewayFacade.AddEmployee(new Employee("Jan"));

            Item item1 = new Item(1, "Pencil", 10, DateTime.Now);
            int rows = gatewayFacade.AddItem(item1);
            gatewayFacade.AddTransactionLog(
                new TransactionLogEntry("Item Added", item1.ID, item1.Name, 0.25f, item1.Quantity, "Graham", DateTime.Now));
            Item item2 = new Item(2, "Eraser", 20, DateTime.Now);
            int rows2 = gatewayFacade.AddItem(item2);
            gatewayFacade.AddTransactionLog(
                new TransactionLogEntry("Item Added", item2.ID, item2.Name, 0.15f, item2.Quantity, "Phil", DateTime.Now));

            item2.RemoveQuantity(4);
            gatewayFacade.RemoveQuantity(item2);
            gatewayFacade.AddTransactionLog(
                new TransactionLogEntry("Quantity Removed", item2.ID, item2.Name, -1, 4, "Graham", DateTime.Now));

            item2.AddQuantity(2);
            gatewayFacade.AddQuantity(item2);
            gatewayFacade.AddTransactionLog(
                new TransactionLogEntry("Quantity Added", item2.ID, item2.Name, 0.33, 2, "Phil", DateTime.Now));


            return new MassageDTO("The database has been initialised");

    }

        public override Dictionary<int, ItemDTO> ExecuteGrid()
        {
            throw new NotImplementedException();
        }
    }
}
