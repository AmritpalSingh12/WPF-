using Assignment.CommandLineUI.Presenter;
using Assignment.DTOs;
using Controller.Controller;
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

namespace WPF_Ass
{
    /// <summary>
    /// Interaction logic for ViewItemWindow.xaml
    /// </summary>
    public partial class ViewItemWindow : Window
    {
        public ViewItemWindow()
        {
            InitializeComponent();



            ViewInventoryController controller1 =
            new ViewInventoryController(
                    new MessagePresenter());

            var itemDto =
                controller1.ExecuteGrid();
            dgViewItems.ItemsSource = itemDto;

            //List<ItemGridDTO> itemGridlist = new List<ItemGridDTO>();
            //foreach (var item in dictionaryitems)
            //{
            //    ItemGridDTO itemGrid = new ItemGridDTO();



            //    itemGrid.ItemId = item.Value.ID;
            //    itemGrid.ItemName = item.Value.Name;
            //    itemGrid.ItemQuantity = item.Value.Quantity;
            //    itemGrid.Addeddate = item.Value.DateCreated;

            //    itemGridlist.Add(itemGrid);


            //    dgViewItems.ItemsSource = itemGridlist;
            //}
        }
    }
}
              
   
        

