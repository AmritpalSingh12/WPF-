using System;
using System.Collections.Generic;
using System.Text;

namespace Server.menu
{
    public abstract class MenuElement
    {
        public int Id { get; }
        public string Text { get; }

        public MenuElement(int id, string text)
        {
            this.Id = id;
            this.Text = text;
        }

        public abstract void Print(string indent);
    }
    

}
