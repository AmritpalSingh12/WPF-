using Client.MyClients;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPF_Ass;

namespace Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        private MyWPFClient client;
         Task clientTask;

        public MainWindow()
        {
            InitializeComponent();
            //client = new MyWPFClient(AppendBroadcastMessage, GetMessageToBroadcast, ShowMessage, DisplayVerse);
            // clientTask = Task.Run(client.Run);

            Task.Run(MyWPFClientSingleton.Instance.Run);
        }
       

        private void AddItem_click(object sender, RoutedEventArgs e)
        {
            AddItemWindow addItem = new AddItemWindow();
            addItem.Show();

        }

        private void ViewItem_click(object sender, RoutedEventArgs e)
        {
            ViewItemWindow viewItemWindow = new ViewItemWindow();
            viewItemWindow.Show();
        }

        private void AddQuantity_click(object sender, RoutedEventArgs e)
        {
            AddQuantityWindow addQuantity = new AddQuantityWindow();
            addQuantity.Show();
        }

        private void RemoveQuantity_click(object sender, RoutedEventArgs e)
        {
            RemoveQuantityWindow removeQuantityWindow = new RemoveQuantityWindow();
            removeQuantityWindow.Show();
        }

        private void viewFinance_click(object sender, RoutedEventArgs e)
        {
            ViewFinancialWindow viewFinancialWindow = new ViewFinancialWindow();
            viewFinancialWindow.Show();
        }

        private void viewTransaction_click(object sender, RoutedEventArgs e)
        {
            ViewTransactionWindow viewTransactionWindow = new ViewTransactionWindow();
            viewTransactionWindow.Show();
        }

        private void viewPersonal_click(object sender, RoutedEventArgs e)
        {
            PersonalUsageWindow personalUsageWindow = new PersonalUsageWindow();
            personalUsageWindow.Show();
        }

        

        private void click_rapid(object sender, RoutedEventArgs e)
        {
            //MyWPFClientSingleton.Instance.AddCommand("RapidRequest");

            for (int i = 1; i < 201; i++)
            {
                MyWPFClientSingleton.Instance.AddCommand("RapidRequest");
                MyWPFClientSingleton.Instance.JsonCommand(i.ToString());

                Task.Yield();
            }
        }
    }
}
