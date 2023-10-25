using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WPF_Ass.Entities;

namespace WPF_Ass
{
    /// <summary>
    /// Interaction logic for DeleteWindow.xaml
    /// </summary>
    public partial class DeleteWindow : Window
    {
        public DeleteWindow()
        {
            InitializeComponent();
        }

        private Dictionary<int, Item> _items;
        public DeleteWindow(Dictionary<int, Item> items) : base()
        {
            InitializeComponent();
            _items = items;

        }
        private void Deleteitem_Click(object sender, RoutedEventArgs e)
        {
            int ID = 0;

            if (txt_IDDelete.Text != string.Empty)
            {

                ID = Convert.ToInt32(txt_IDDelete.Text);
                Item item = this.FindItem(ID);

                if (item != null)
                {
                    _items.Remove(ID);
                }
            }
        }

        public Item FindItem(int id)
        {
            if (_items.ContainsKey(id))
            {
                return _items[id];
            }
            else
                return null;
        }
    }
}
