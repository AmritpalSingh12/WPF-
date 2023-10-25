using Assignment.CommandLineUI.Commands;
using Assignment.CommandLineUI.Menu;
using Assignment.UI_commands;
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

namespace WPF_Ass
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            InitializeComponent();

            CommandFactory factory = new CommandFactory();
            try
            {
                factory
                    .CreateCommand(RequestUseCase.INITIALISE_DATABASE)
                    .Execute();

                MenuFactory.INSTANCE.Create().Print("");
               // int choice = GetUserChoice();

              //  while (choice != RequestUseCase.EXIT)
               // {
               //     factory
               //         .CreateCommand(choice)
                  //      .Execute();

                  //  MenuFactory.INSTANCE.Create().Print("");
                   // choice = GetUserChoice();
            //    }
           }
            catch (Exception e)
           {
                Console.WriteLine("\nERROR: " + e.Message);
            }
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
    }
}
