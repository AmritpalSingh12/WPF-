using Assignment.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.visi
{
    public class VisitableItem : Visitable
    {
        private ItemDTO item;

        public int ID
        {
            get { return item.ID; }
        }

        public string Name
        {
            get
            {
                return item.Name;
            }
        }

        public int Quantity
        {
            get
            {
                return item.Quantity;
            }
        }

        public DateTime DateCreated
        {
            get { return item.DateCreated; }
        }


        public VisitableItem(ItemDTO item)
        {
            this.item = item;
        }

        public void AcceptVisitFrom(Visitor v)
        {
            v.VisitItem(this);
        }

    }
}
