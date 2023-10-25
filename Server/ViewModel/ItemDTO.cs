

using System;
using System.Collections.Generic;
using System.Text;

namespace Server.DTOs
{

    [Serializable]
    public class ItemDTO : DTO
    {
        public int ID { get; }
        public string Name { get; }
        public int Quantity { get; private set; }
        public DateTime DateCreated { get; }



        public ItemDTO(int id, string name, int quantity, DateTime dateCreated)
        { 

            this.ID = id;
            this.Name = name;
            this.Quantity = quantity;
            this.DateCreated = dateCreated;
        }


    }
}
