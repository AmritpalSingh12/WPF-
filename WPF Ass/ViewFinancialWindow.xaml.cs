using Assignment.CommandLineUI.Presenter;
using Assignment.Library;
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
    /// Interaction logic for ViewFinancialWindow.xaml
    /// </summary>
    public partial class ViewFinancialWindow : Window
    {
        public ViewFinancialWindow()
        {
            InitializeComponent();

            ViewFinancialReportController controller =
                new ViewFinancialReportController(
                    new MessagePresenter());


            var data = controller.ExecuteUseCaseFinancial();
            //  lvFinance.ItemsSource = data;

            double total = 0;
            string display = string.Empty;
            foreach (TransactionLogEntry entry in data)
            {
                if (entry.TypeOfTransaction.Equals("Item Added")
                    || entry.TypeOfTransaction.Equals("Quantity Added"))
                {
                    double cost = entry.ItemPrice * entry.Quantity;
                    display = display + $"{entry.ItemName}: Total price of item : £{Math.Round(cost, 2)}";
                    display = display + Environment.NewLine;
                 //   Console.WriteLine("{0}: Total price of item: {1:C}", entry.ItemName, cost);
                    total += cost;
                }
            }
            lblPrice.Content = display;

            string totalprice = String.Format("{0}: {1:C}", "Total price of all items", total);
            lblTotalPrice.Content = totalprice;
        }
    }
}
