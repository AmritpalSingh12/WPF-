using Server.DTOs;
using Server.Entities;
using Server.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.UseCases
{
    public class ViewInventory : AbstractUseCase
    {
        private object gatewasyFacade;

        public ViewInventory(IDataGatewayFacade gatewayFacade) : base(gatewayFacade)
        {

        }


        public override DTO Execute()
        {
            Dictionary<int, ItemDTO> items = gatewayFacade.GetItems();
            Console.WriteLine("\nAll items");
            Console.WriteLine(
                "\t{0, -4} {1, -20} {2, -20}",
                "ID",
                "Name",
                "Quantity");

            foreach (ItemDTO i in items.Values)
            {
                ViewInventoryReport(i);
            }
            return new MassageDTO("All items");

        }
        public void ViewInventoryReport(ItemDTO i)
        {
            Console.WriteLine(
                        "\t{0, -4} {1, -20} {2, -20}",
                        i.ID,
                        i.Name,
                        i.Quantity);


        }
        public override Dictionary<int, ItemDTO> ExecuteGrid()
        {
            Dictionary<int, ItemDTO> items = gatewayFacade.GetItems();
            Console.WriteLine(
                "\t{0, -4} {1, -20} {2, -20}",
                "ID",
                "Name",
                "Quantity");
            foreach (ItemDTO i in items.Values)
            {
                ViewInventoryReport(i);
            }


            return items;
           

        }


    }


    }

