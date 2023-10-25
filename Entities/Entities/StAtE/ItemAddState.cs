using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.s
{
    public abstract class ItemAddState
    {
        public int numberOfItems { get; }
        public DateTime addedDate { get; }


        protected ItemAddState(int numberOfItems, DateTime addedDate)
        {
            this.numberOfItems = numberOfItems;
            this.addedDate = addedDate;
        }

        public abstract ItemAddState AddNew();

        public virtual bool WasAdded()
        {
            return false;
        }
    }
}
