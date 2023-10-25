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
    /// Interaction logic for ViewTransactionWindow.xaml
    /// </summary>
    public partial class ViewTransactionWindow : Window
    {
        public ViewTransactionWindow()
        {
            InitializeComponent();

            ViewTransactionController controller =
               new ViewTransactionController(
                   new MessagePresenter());


            var data = controller.TransactionLogs();
            dgTransaction.ItemsSource = data;

        }
    }
}
