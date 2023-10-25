using Assignment.CommandLineUI.Presenter;
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
    /// Interaction logic for RemoveQuantityWindow.xaml
    /// </summary>
    public partial class RemoveQuantityWindow : Window
    {
        public RemoveQuantityWindow()
        {
            InitializeComponent();
        }
       

        private void removequantityitem_click(object sender, RoutedEventArgs e)
        {
            string employeeName = string.Empty;
         
            int itemID = 0;
            int itemQuantity = 0;
            bool isvalid = true;


            if (txtEmployeeName.Text != string.Empty)
            {
                lblMSGEmployeeName.Content = string.Empty;
                employeeName = txtEmployeeName.Text;
            }
            else
            {
                isvalid = false;
                lblMSGEmployeeName.Content = "Please enter Employee Name";
            }

            if (txtItemID.Text != string.Empty)
            {
                lblMSGItemID.Content = string.Empty;
                itemID = Convert.ToInt32(txtItemID.Text);
            }
            else
            {
                isvalid = false;
                lblMSGItemID.Content = "Please enter Item ID";
            }

            if (txtRemove.Text != string.Empty)
            {
                lblMSGRemoveQuantity.Content = string.Empty;
                itemQuantity = Convert.ToInt32(txtRemove.Text);
            }
            else
            {
                isvalid = false;
                lblMSGRemoveQuantity.Content = "Please enter Item Quantity";
            }


                if (isvalid)
                {

                    txtEmployeeName.Text = string.Empty;
                    txtItemID.Text = string.Empty;
                    txtRemove.Text = string.Empty;


                    RemoveQuantityController controller =
               new RemoveQuantityController(
                   employeeName,
                  itemID,
                  itemQuantity,

                   new MessagePresenter());

                    CommandLineViewData data =
                   (CommandLineViewData)controller.Execute();

                }
            }
        }
    }


