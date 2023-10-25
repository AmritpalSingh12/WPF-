using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.s
{
    public class RemoveQuantityOfItemState : ItemAddState
    {

        private bool wasAdded;
    
            public RemoveQuantityOfItemState(int numberOfItems, DateTime addedDate) : base(numberOfItems, addedDate)
            {
            wasAdded = true;
            }

            public override ItemAddState AddNew()
            {
                wasAdded = true;
                return this;
            }

            public override bool WasAdded()
            {
                return wasAdded;
            }
        }
    }

