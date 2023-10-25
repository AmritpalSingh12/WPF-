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
    /// Interaction logic for PersonalUsageWindow.xaml
    /// </summary>
    public partial class PersonalUsageWindow : Window
    {
        public PersonalUsageWindow()
        {
            InitializeComponent();
        }

        private void Personal_click(object sender, RoutedEventArgs e)
        {
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

                txtEmployeeName.Text = string.Empty;

                PersonalController controller =
              new PersonalController(
                  employeeName,
                

                  new MessagePresenter());

                var personal =
                controller.ExecutePersonalUsage();
                dgPersonal.ItemsSource = personal;

                
            }


        }

        private void txtItemName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
    }

