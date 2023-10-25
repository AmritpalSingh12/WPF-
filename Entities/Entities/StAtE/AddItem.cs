using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.s
{
    public class AddItem : ItemAddState
    {

        public AddItem( int numberOfItems , DateTime addedDate) : base (numberOfItems, addedDate)
        {

        }
        public override ItemAddState AddNew()
        {
            return ItemCreateStateFactory.Create(numberOfItems + 1, addedDate.AddDays(1));
        }
    }
}
