using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Entities
{
    public class ItemDictionary
    {
        private readonly Dictionary<int, Item> _items = new Dictionary<int, Item>();

        public void AddItem(Item item)
        {
            try
            {
                _items[item.ID].AddQuantity(item.Quantity);
            }

            catch (KeyNotFoundException)
            {
                _items.Add(item.ID, item);
            }
        }

            public Item FindItem(int id )
            {
                try
                {
                    return _items[id];
                }
            catch(KeyNotFoundException)
            {
                return null;
            }
            }

        public void Remove(Item item)
        {
            try
            {
                _items[item.ID].RemoveQuantity(item.Quantity);
            }

            catch (KeyNotFoundException)
            {
                _items.Add(item.ID, item);
            }
        }


    }
    }

