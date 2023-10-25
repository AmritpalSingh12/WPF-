using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.s
{
    public class ItemCreateStateFactory
    {
        public static ItemAddState Create ( int numberOfItems , DateTime addedDate)
        {
            if (numberOfItems == 0) 
            {
                return new AddItem (numberOfItems, addedDate);
            }
            else if (numberOfItems < 2)
            {
                return new AddQuantityToItemState (numberOfItems, addedDate);
            }
            else
            {
                return new RemoveQuantityOfItemState (numberOfItems, addedDate);
            }

        }
            
     }
}
