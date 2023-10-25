using Client;
using Client.DTOs;
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
    /// Interaction logic for ViewItemWindow.xaml
    /// </summary>
    public partial class ViewItemWindow : Window
    {
        private TcpClient tcpClient;
        private NetworkStream stream;
        private StreamReader reader;
        private StreamWriter writer;
        MyWPFClient _client;

        public ViewItemWindow()
        {
            InitializeComponent();

            // Task.Run(MyWPFClientSingleton.Instance.Run);

            //this.ConnecttoServer();

            //writer.WriteLine("ViewItem");

            //string jsonitemDTO = reader.ReadLine();

            //List<ItemGridDTO> itemlist = JsonSerializer.Deserialize<List<ItemGridDTO>>(jsonitemDTO);

            //dgViewItems.ItemsSource = itemlist;

            //tcpClient.Close();

            MyWPFClientSingleton.Instance.AddCommand("ViewItem");
            MyWPFClientSingleton.Instance.ObjectCommadnd(this);




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
              
   
        

