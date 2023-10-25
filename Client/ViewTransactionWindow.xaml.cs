
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
    /// Interaction logic for ViewTransactionWindow.xaml
    /// </summary>
    public partial class ViewTransactionWindow : Window
    {
        private TcpClient tcpClient;
        private NetworkStream stream;
        private StreamReader reader;
        private StreamWriter writer;
        public ViewTransactionWindow()
        {
            InitializeComponent();

            //this.ConnecttoServer();

            //writer.WriteLine("ViewTransaction");

            //string jsonviewTransaction = reader.ReadLine();

           // List<TransactionViewModel> itemlist = JsonSerializer.Deserialize<List<TransactionViewModel>>(jsonviewTransaction);

            //dgTransaction.ItemsSource = itemlist;

            MyWPFClientSingleton.Instance.AddCommand("ViewTransaction");
           
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
    

