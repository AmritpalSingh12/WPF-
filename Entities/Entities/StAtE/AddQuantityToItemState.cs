using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.s
{
    public class AddQuantityToItemState : ItemAddState
    {
        public AddQuantityToItemState( int numberOfItems , DateTime addedDate) : base (numberOfItems, addedDate)
        {

        }

        public override ItemAddState AddNew()
        {
            return ItemCreateStateFactory.Create(numberOfItems + 1, addedDate.AddDays(1));
        }

        public override bool WasAdded()
        {
            return true;
        }
    }
}
