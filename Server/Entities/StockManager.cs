
using System;
using System.Collections.Generic;

namespace Server.Entities
{
    public class StockManager
    {
        private Dictionary<int, Item> items;

        public int NumberOfItemsInStock
        {
            get
            {
                return items.Count;
            }
        }

        public StockManager()
        {
            items = new Dictionary<int, Item>();
        }

        public Item AddItem(int id, string name, int quantity)
        {
            if (FindItem(id) != null)
            {
                throw new Exception("Item is already in stock. Quantity NOT updated");
            }

            Item i = new Item(id, name, quantity, DateTime.Now);
            items.Add(i.ID, i);
            return i;

        }


        public Item FindItem(int itemId)
        {
            try
            {
                return items[itemId];
            }
            catch (KeyNotFoundException)
            {
                return null;
            }
        }

        public Dictionary<int, Item>.ValueCollection GetItems()
        {
            return items.Values;
        }
    }
}
