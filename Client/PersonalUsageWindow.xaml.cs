
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
    /// Interaction logic for PersonalUsageWindow.xaml
    /// </summary>
    public partial class PersonalUsageWindow : Window
    {
        private TcpClient tcpClient;
        private NetworkStream stream;
        private StreamReader reader;
        private StreamWriter writer;

        public PersonalUsageWindow()
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


        private void Personal_click(object sender, RoutedEventArgs e)
        {
            //this.ConnecttoServer();

            string employeeName = string.Empty;
            bool isvalid = true;

            if (txtEmployeeName.Text != string.Empty)
            {
                lblMSGEmployee.Content = string.Empty;
                employeeName = txtEmployeeName.Text;
            }
            else
            {
                isvalid = false;
                lblMSGEmployee.Content = "Please enter Employee Name";
            }

            if (isvalid)
            {

                TransactionViewModel personalView = new TransactionViewModel();

                personalView.EmployeeName = employeeName;

                string json = JsonSerializer.Serialize(personalView);

                //writer.WriteLine("ViewPersonal");
               // writer.WriteLine(json);

                MyWPFClientSingleton.Instance.AddCommand("ViewPersonal");
                MyWPFClientSingleton.Instance.JsonCommand(json);
                MyWPFClientSingleton.Instance.ObjectCommadnd(this);

                //string Message = reader.ReadLine();

                //string jsonviewPersonal = reader.ReadLine();

                //List<TransactionViewModel> personalview = JsonSerializer.Deserialize<List<TransactionViewModel>>(jsonviewPersonal);

                //dgPersonal.ItemsSource = personalview;

                //tcpClient.Close();

                txtEmployeeName.Text = string.Empty;

            }
        }
        private void txtItemName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
        
            

            

        
    



