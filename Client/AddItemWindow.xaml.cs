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

namespace Client
{
    /// <summary>
    /// Interaction logic for AddItemWindow.xaml
    /// </summary>
    /// 


    public partial class AddItemWindow : Window
    {
        private TcpClient tcpClient;
        private NetworkStream stream;
        private StreamReader reader;
        private StreamWriter writer;
        MyWPFClient _client;

       


        public AddItemWindow()
        {
            InitializeComponent();
          
        }

        private void AppendBroadcastMessage(List<string> msg)
        {
             msg.ForEach(s => Dispatcher.Invoke(() => "Test A"));
            Dispatcher.Invoke(() => "Test B");
        }

        private string GetMessageToBroadcast()
        {
            return Dispatcher.Invoke(() => "Test C");
             
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

            catch(Exception ex)
            {
                throw ex;
                return false;
            }
                
        }

        private void btn_Submit_Click(object sender, RoutedEventArgs e)
        {
            // this.ConnecttoServer();

            

            bool isvalid = true;

            int itemID = 0;
            string itemName = string.Empty;
            int itemQuantity = 0;

            //string EmployeeName = null;
            string employeeName = string.Empty;
            double itemPrice = 0;



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

            //string ItemName = null;
            if (txtItemName.Text != string.Empty)
            {

                lblMSGItemName.Content = string.Empty;
                itemName = txtItemName.Text;
            }
            else
            {
                isvalid = false;
                lblMSGItemName.Content = "Please enter Item Name";
            }

            //int ItemQuantity = 0;
            if (txtItemQuantity.Text != string.Empty)
            {
                lblMSGQuantity.Content = string.Empty;
                itemQuantity = Convert.ToInt32(txtItemQuantity.Text);
            }
            else
            {
                isvalid = false;
                lblMSGQuantity.Content = "Please enter Item Quantity";

            }

            //int ItemID = 0;
            if (txtItemId.Text != string.Empty)
            {
                lblMSGItemID.Content = string.Empty;
                itemID = Convert.ToInt32(txtItemId.Text);
            }
            else
            {
                isvalid = false;
                lblMSGItemID.Content = "Please enter Item ID";
            }


            //double ItemPrice = 0;
            if (txtItemPrice.Text != string.Empty)
            {
                lblMSGPrice.Content = string.Empty;
                itemPrice = Convert.ToDouble(txtItemPrice.Text);
            }
            else
            {
                isvalid = false;
                lblMSGPrice.Content = "Please enter Item Price";
            }
            if (isvalid)
            {
                //AddItem addItem = new AddItem(employeeName,  itemPrice, itemID,  itemName,  itemQuantity, DateTime.Now);

                ItemViewModel itemViewModel = new ItemViewModel();
                itemViewModel.itemID = itemID;
                itemViewModel.itemName = itemName;  
                itemViewModel.itemQuantity = itemQuantity;
                itemViewModel.itemPrice = itemPrice;
                itemViewModel.employeeName = employeeName;

                string json = JsonSerializer.Serialize(itemViewModel);

                MyWPFClientSingleton.Instance.AddCommand("AddItem");
                MyWPFClientSingleton.Instance.JsonCommand(json);
                MyWPFClientSingleton.Instance.ObjectCommadnd(this);

                //writer.WriteLine("AddItem");
                //writer.WriteLine(json);
                //string Message = reader.ReadLine();

                //string jsonitemDTO = reader.ReadLine();

                //List<ItemGridDTO> itemlist = JsonSerializer.Deserialize<List<ItemGridDTO>>(jsonitemDTO);

                // dgItems.ItemsSource = itemlist;




                // tcpClient.Close();

                //items.Add(addItem);

                //dgItems.ItemsSource= items;
                //_items.Add(item.ID, item);
                //lblMSG.Content = "Save Succesfully";
                // MessageBox.Show($"Save Succesfully and Total items are {_items.Count}");
                txtEmployeeName.Text = string.Empty;
                txtItemId.Text = string.Empty;
                txtItemName.Text = string.Empty;
                txtItemPrice.Text = string.Empty;
                txtItemQuantity.Text = string.Empty;

               // AddItemController controller =
               // new AddItemController(
               //     employeeName,
               //    itemID,
               //     itemName,
               //    itemQuantity,
               //     itemPrice,
               //     new MessagePresenter());

               // CommandLineViewData data =
               //(CommandLineViewData)controller.Execute();

               // ViewInventoryController controller1 =
               // new ViewInventoryController(
               //         new MessagePresenter());

                //var itemDTO =
                //    controller1.ExecuteGrid();
                //dgItems.ItemsSource = itemDTO;

                //List<ItemGridDTO> itemGridlist = new List<ItemGridDTO>();
                //foreach (var item in dictionaryitems) { 
                //ItemGridDTO itemGrid = new ItemGridDTO();

                //    itemGrid.ItemId = item.Value.ID;
                //    itemGrid.ItemName= item.Value.Name;
                //    itemGrid.ItemQuantity = item.Value.Quantity;
                //    itemGrid.Addeddate = item.Value.DateCreated;

                //    itemGridlist.Add(itemGrid);
                //}



            }



            // AddItemController controller =
            //   new AddItemController(
            //       itemvm.employeeName,
            //      itemvm.itemID,
            //       itemvm.itemName,
            //      itemvm.itemQuantity,
            //       itemvm.itemPrice,
            //       new MessagePresenter());

            // CommandLineViewData data =
            //(CommandLineViewData)controller.Execute();
        }

        public void DisplayItems(List<ItemGridDTO> itemlist)
        {
            
        }


        
    }

    

}


