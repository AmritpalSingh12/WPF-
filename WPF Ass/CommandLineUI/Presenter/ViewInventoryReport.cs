using Assignment.DTOs;
using Assignment.UseCases;
using Assignment.visi;
using System;
using System.Collections.Generic;
using System.Text;
using UseCases.UseCases;

namespace Assignment.CommandLineUI.Presenter
{
    class ViewInventoryReport : AbstractPresenter
    {

        public override ViewData ViewData
        {
            get
            {
                Dictionary<int, ItemDTO> items = ((ItemDTO_List)DataToPresent).List;
                List<string> lines = new List<string>();


                lines.Add("\nAll items");
                lines.Add(string.Format(
                    "\t{0, -4} {1, -20} {2, -20}",
                    "ID",
                    "Name",
                    "Quantity"));


                foreach(ItemDTO i in items.Values)
                {
                    ViewInventory(i);
                }

                return new CommandLineViewData(lines);

            }
        }

            private string ViewInventory(ItemDTO i)
        {
            return string.Format(
                "\t{0, -4} {1, -20} {2, -20}",
                i.ID,
                i.Name,
                i.Quantity


                );
        }

        }

       


    }

