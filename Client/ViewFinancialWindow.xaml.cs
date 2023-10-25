
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
    /// Interaction logic for ViewFinancialWindow.xaml
    /// </summary>
    public partial class ViewFinancialWindow : Window
    {
        private TcpClient tcpClient;
        private NetworkStream stream;
        private StreamReader reader;
        private StreamWriter writer;
        public ViewFinancialWindow()
        {
            InitializeComponent();

            //this.ConnecttoServer();

            //writer.WriteLine("ViewFinancial");

            //string jsonviewFinancial = reader.ReadLine();

            //List<TransactionViewModel> itemlist = JsonSerializer.Deserialize<List<TransactionViewModel>>(jsonviewFinancial);

            //double total = 0;
            //string display = string.Empty;
            //foreach (TransactionViewModel entry in itemlist)
            //{
            //    if (entry.TypeOfTransaction.Equals("Item Added")
            //        || entry.TypeOfTransaction.Equals("Quantity Added"))
            //    {
            //        double cost = entry.ItemPrice * entry.Quantity;
            //        display = display + $"{entry.ItemName}: Total price of item : £{Math.Round(cost, 2)}";
            //        display = display + Environment.NewLine;
            //        //   Console.WriteLine("{0}: Total price of item: {1:C}", entry.ItemName, cost);
            //        total += cost;
            //    }
            //}
            //lblPrice.Content = display;

            //string totalprice = String.Format("{0}: {1:C}", "Total price of all items", total);
            //lblTotalPrice.Content = totalprice;


            MyWPFClientSingleton.Instance.AddCommand("ViewFinancial");
            
            MyWPFClientSingleton.Instance.ObjectCommadnd(this);

            //tcpClient.Close();
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
    }
}
