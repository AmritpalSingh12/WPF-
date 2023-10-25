using Assignment.DTOs;
using Assignment.Library;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.DTOs
{
    public class Item_Converter : IConverter<ItemDTO, Item>
    {

        

        public Item ConvertFromDTO(ItemDTO itemDTO)
        {
            return
                new ItemBuilder()
                    .WithItem(itemDTO.Name)
                    .WithID(itemDTO.ID)
                    .WithQuantity(itemDTO.Quantity)
                    .WithDateCreated(itemDTO.DateCreated)
                    .Build();
        }

        public ItemDTO ConvertToDTO(Item item )
        {
            return
                new ItemDTO_Builder()
               .WithItem(item.Name)
                    .WithID(item.ID)
                    .WithQuantity(item.Quantity)
                    .WithDateCreated(item.DateCreated)
                    .Build();
        }
    }

    


}

    
    

