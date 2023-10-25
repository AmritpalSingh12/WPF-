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
    /// Interaction logic for AddQuantityWindow.xaml
    /// </summary>
    public partial class AddQuantityWindow : Window
    {
        public AddQuantityWindow()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void click_addquantity(object sender, RoutedEventArgs e)
        {
            string employeeName = string.Empty;
            double itemPrice = 0;
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

            if (txtAdd.Text != string.Empty)
            {
                lblMSGAddQuantity.Content = string.Empty;
                itemQuantity = Convert.ToInt32(txtAdd.Text);
            }
            else
            {
                isvalid = false;
                lblMSGAddQuantity.Content = "Please enter Item Quantity";

            }
            if (txtPrice.Text != string.Empty)
            {
                lblMSGItemPrice.Content = string.Empty;
                itemPrice = Convert.ToDouble(txtPrice.Text);
            }
            else
            {
                isvalid = false;
                lblMSGItemPrice.Content = "Please enter Item Price";
            }
            if (isvalid)
            {



                txtEmployeeName.Text = string.Empty;
                txtItemID.Text = string.Empty;
                
                txtPrice.Text = string.Empty;
                txtAdd.Text = string.Empty;


                AddQuantityContoller controller =
               new AddQuantityContoller(
                   employeeName,
                  itemID,
                  itemQuantity,
                   itemPrice,
                   new MessagePresenter());

                CommandLineViewData data =
               (CommandLineViewData)controller.Execute();

            }
        }
    }
}


