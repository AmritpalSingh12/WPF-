using Server.DTOs;
using Server.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Server.DataGateway.MySql
{
    public class DatabaseOperationFactoryItem
    {
        public const int SELECT_ALL_ITEM = 1;
        public const int FIND_ITEM_BY_ID = 2;
        public const int UPDATE_ADD_QUANTITY = 3;
        public const int UPDATE_REMOVE_QUANTITY = 4;

        public DatabaseInserter<Item> CreateInserter()
        {
            return new InsertItem();
        }

        public ISelector<Dictionary<int, ItemDTO>> CreateSelector(int typeOfSelection)
        {
            if (typeOfSelection == SELECT_ALL_ITEM)
            {
                return new GetAllItems();

            }
            return new NullSelector<Dictionary<int, ItemDTO>>();
        }

        public ISelector<Item> CreateSelector(int typeOfSelection, int id)
        { 
            switch (typeOfSelection)
            {
              case FIND_ITEM_BY_ID:
                    return new FindItembyID(id);
                default:
                    return new NullSelector<Item>();
            }
            
        }

        public IUpdater<Item> CreateUpdater(int typeOfUpdate)
        {
            switch(typeOfUpdate)
            {
                case UPDATE_ADD_QUANTITY:
                    return new UpdateAddQuantity();
                case UPDATE_REMOVE_QUANTITY:
                    return new UpdateRemoveQuantity();

                default:
                    return null;
            }
        }

    }
}
