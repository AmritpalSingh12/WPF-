using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewModel
{
     public class ItemViewModel
    {
        public int itemID { get; set; }
        public string itemName { get; set; }
        public int itemQuantity { get;  set; }
       
        public string employeeName { get; set; }

        public double itemPrice { get; set; }

        public DateTime DateCreated { get; }



    }
}
