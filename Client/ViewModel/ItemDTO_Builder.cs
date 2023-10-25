using System;
using System.Collections.Generic;
using System.Text;

namespace Client.DTOs
{ 
    public class ItemDTO_Builder
    {
        public int ID;
        public string Name;
        public int Quantity;
        public DateTime DateCreated;


        public ItemDTO_Builder()
        {
            ID = -1;
            Name = null;
            Quantity = 0;
        }

        public ItemDTO Build()
        {
            return new ItemDTO(ID, Name, Quantity, DateCreated);
        }

        public ItemDTO_Builder WithItem(string Name)
        {
            this.Name = Name;
            return this;

        }

        public ItemDTO_Builder WithID(int ID)
        {
            this.ID = ID;
            return this;
        }

        public ItemDTO_Builder WithQuantity(int Quantity)
        {
            this.Quantity = Quantity;
            return this;
        }

        public ItemDTO_Builder WithDateCreated(DateTime DateCreated)
        {
            this.DateCreated = DateCreated;
            return this;
        }

    }
}
