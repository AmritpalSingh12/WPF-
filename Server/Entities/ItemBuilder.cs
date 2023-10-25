using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Entities
{
    public class ItemBuilder
    {
        private int ID;
        private string Name;
        private int Quantity;
        private DateTime DateCreated;


        public ItemBuilder()
        {
            this.ID = -1;
            this.Name = null;
            this.Quantity = 0;
        }

        public Item Build()
        {
            return new Item(ID, Name, Quantity, DateCreated);
        }

        public ItemBuilder WithItem(string Name)
        {
            this.Name = Name;
            return this;
           
        }

        public ItemBuilder WithID(int ID)
        {
            this.ID = ID;
            return this;
        }

        public ItemBuilder WithQuantity(int Quantity)
        {
            this.Quantity = Quantity;
            return this;
        }

        public ItemBuilder WithDateCreated(DateTime DateCreated)
        {
            this.DateCreated = DateCreated;
            return this;
        }

    }
}

