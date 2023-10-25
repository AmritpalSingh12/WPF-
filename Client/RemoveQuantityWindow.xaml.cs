
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
    /// Interaction logic for RemoveQuantityWindow.xaml
    /// </summary>
    public partial class RemoveQuantityWindow : Window
    {
        private TcpClient tcpClient;
        private NetworkStream stream;
        private StreamReader reader;
        private StreamWriter writer;

        public RemoveQuantityWindow()
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
                TransactionViewModel transactionView = new TransactionViewModel();

                transactionView.EmployeeName = employeeName;
                transactionView.ItemID = itemID;

                transactionView.Quantity = itemQuantity;

                string json = JsonSerializer.Serialize(transactionView);

          
                MyWPFClientSingleton.Instance.AddCommand("RemoveQuantity");
                MyWPFClientSingleton.Instance.JsonCommand(json);
                MyWPFClientSingleton.Instance.ObjectCommadnd(this);

               // string Message = reader.ReadLine();

               




                txtEmployeeName.Text = string.Empty;
                txtItemID.Text = string.Empty;


                txtRemove.Text = string.Empty;
            }
        }
    }
}



