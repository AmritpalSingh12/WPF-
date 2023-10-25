using System;
using System.Collections.Generic;
using System.Text;

namespace Client.DTOs
{
    public class ItemDTO_List : DTO
    {
        public Dictionary<int,ItemDTO> List { get; }

        public ItemDTO_List(Dictionary<int ,ItemDTO> list)
        {
            this.List = list;
        }


    }
}
