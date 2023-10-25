
using System;

namespace Assignment.Library
{

    [Serializable]
    public class Item : IEntity
    {
        public int ID { get; }
        public string Name { get; }
        public int Quantity { get; private set; }
        public DateTime DateCreated { get; }

        


        public Item(int id, string name, int quantity, DateTime dateCreated)
        {
            string errorMsg = "";

            if (id < 1)
            {
                errorMsg += "ID below 1; ";
            }

            if (quantity < 1)
            {
                errorMsg += "Quantity below 1; ";
            }

            if (name.Length == 0)
            {
                errorMsg += "Item name is empty; ";
            }

            if (errorMsg.Length > 0)
            {
                throw new Exception("ERROR: " + errorMsg);
            }

            ID = id;
            Name = name;
            Quantity = quantity;
            DateCreated = dateCreated;
        }


        public void AddQuantity(int quantity)
        {
            if (quantity < 0)
            {
                throw new Exception("ERROR: Quantity being added is below 0");
            }

            Quantity += quantity;


           /* ItemDTO itemDTO = new ItemDTO(ID, Name, Quantity, DateCreated);
            UpdateAddQuantity updateAddQuantity = new UpdateAddQuantity();
            updateAddQuantity.Update(itemDTO);*/


        }

        public void RemoveQuantity(int quantity)
        {
            if (quantity < 0)
            {
                throw new Exception("ERROR: Quantity being removed is below 0");
            }

            if (quantity > Quantity)
            {
                throw new Exception("ERROR: Quantity too many");
            }

            Quantity -= quantity;

           


        }
    }
}
