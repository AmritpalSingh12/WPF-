using Client;
using Client.MyClients;
using Client.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
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
        private TcpClient tcpClient;
        private NetworkStream stream;
        private StreamReader reader;
        private StreamWriter writer;

        public AddQuantityWindow()
        {
            InitializeComponent();
          
        }
        public bool ConnecttoServer()
        {
            try
            {
                tcpClient = new TcpClient();
                tcpClient.Connect(Constants.url, Constants.port);
                stream = tcpClient.GetStream();
                reader = new StreamReader(stream);
                writer = new StreamWriter(stream) { AutoFlush = true };

                return true;
            }

            catch (Exception ex)
            {
                throw ex;
                return false;
            }
        }

    private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void click_addquantity(object sender, RoutedEventArgs e)
        {
            //this.ConnecttoServer();

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
                TransactionViewModel transactionView = new TransactionViewModel();

                transactionView.EmployeeName = employeeName;
                transactionView.ItemID = itemID;
                transactionView.ItemPrice = itemPrice;
                transactionView.Quantity = itemQuantity;

                string json = JsonSerializer.Serialize(transactionView);

                //writer.WriteLine("AddQuantity");
                //writer.WriteLine(json);

                MyWPFClientSingleton.Instance.AddCommand("AddQuantity");
                MyWPFClientSingleton.Instance.JsonCommand(json);
                MyWPFClientSingleton.Instance.ObjectCommadnd(this);

                //string Message = reader.ReadLine();

                //tcpClient.Close();

               


                txtEmployeeName.Text = string.Empty;
                txtItemID.Text = string.Empty;

                txtPrice.Text = string.Empty;
                txtAdd.Text = string.Empty;
            }
        }
    }
}


