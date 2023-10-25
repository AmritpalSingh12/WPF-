using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Ass.UseCase
{
    public class AddItem
    {
        private string employeeName;
        private double itemPrice;
        private int itemId;
        private string itemName;
        private int itemQuantity;
        private DateTime addeddate;
        public int Item_id { 
        get { return itemId; }
        }
        public string Item_Name
        {
            get { return itemName; }
        }
        public int Item_Quantity
        {
            get { return itemQuantity; }
        }
        public DateTime Addeddate
        {
            get { return addeddate; }
        }

        public AddItem(string employeeName, double itemPrice, int itemId, string itemName, int itemQuantity, DateTime addeddate)
        {
            this.employeeName = employeeName;
            this.itemPrice = itemPrice;
            this.itemId = itemId;
            this.itemName = itemName;
            this.itemQuantity = itemQuantity;
            this.addeddate = DateTime.Now;
        }
    }
}
