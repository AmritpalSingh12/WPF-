using Client.DTOs;
using Client.ViewModel;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text.Json;
using System.Threading.Tasks;
using WPF_Ass;

namespace Client.MyClients
{
    public class MyWPFClient
    {
        private TcpClient tcpClient;
        private NetworkStream stream;
        private StreamReader reader;
        private StreamWriter writer;
        private bool clientRunning;

        private ConcurrentQueue<List<string>> messages;
        private BlockingCollection<string> commands;
        private BlockingCollection<string> jsonCommands;
        private BlockingCollection<object> objectCommands;

        private DisplayBroadcastMessage DisplayBroadcastMessage;
        private GetMessageToBroadcast GetMessageToBroadcast;
        private ShowMessage ShowMessage;
        private DisplayVerse DisplayVerse;

        public MyWPFClient(DisplayBroadcastMessage DisplayBroadcastMessage, GetMessageToBroadcast GetMessageToBroadcast, ShowMessage ShowMessage, DisplayVerse DisplayVerse)
        {
            tcpClient = new TcpClient();
            messages = new ConcurrentQueue<List<string>>();
            commands = new BlockingCollection<string>();
            jsonCommands = new BlockingCollection<string>();
            objectCommands = new BlockingCollection<object>();
            this.DisplayBroadcastMessage = DisplayBroadcastMessage;
            this.GetMessageToBroadcast = GetMessageToBroadcast;
            this.ShowMessage = ShowMessage;
            this.DisplayVerse = DisplayVerse;
        }

        public void Run()
        {
            clientRunning = true;

            if (Connect("localhost", 4444))
            {
                Task.Run(ReadFromServer);
                Task.Run(DisplayMessages);

                while (clientRunning)
                {
                    string userInput = commands.Take();

                    string msgToBroadcast = "";
                    if (userInput != "ViewItem" && userInput != "ViewFinancial" && userInput != "ViewTransaction")
                    {
                         msgToBroadcast = jsonCommands.Take();
                    }
                    object windowObject = null;

                    if (userInput != "RapidRequest")
                    {
                        windowObject = objectCommands.Take();
                    }

                    

                    //string msgToBroadcast = jsonCommands.Take();

                    //if (userInput == 'B')
                    //{
                    //    msgToBroadcast = GetMessageToBroadcast();
                    //}
                    WriteToServer(userInput, msgToBroadcast, windowObject);
                    ReadFromServerTo();
                }
            }
            else
            {
                ShowMessage("ERROR: Connection to server not successful");
            }
            tcpClient.Close();
        }

        private bool Connect(string url, int portNumber)
        {
            try
            {
                tcpClient.Connect(url, portNumber);
                stream = tcpClient.GetStream();
                reader = new StreamReader(stream, System.Text.Encoding.UTF8);
                writer = new StreamWriter(stream, System.Text.Encoding.UTF8);
            }
            catch (Exception e)
            {
                ShowMessage("Exception: " + e.Message);
                return false;
            }
            return true;
        }

        //private void WriteToServer(object obj)
        //{
        //    if (obj is ItemViewModel)
        //    {
        //        string json = JsonSerializer.Serialize(obj);

        //        writer.WriteLine("AddItem");
        //        writer.WriteLine(json);
        //    }

        //}

        private void WriteToServer(string userChoice, string broadcastMessage, object window= null)
        {
            if (userChoice == "AddItem")
            {

                writer.WriteLine("" + userChoice);
                writer.WriteLine(broadcastMessage);
                writer.Flush();
            }

            else if (userChoice == "ViewItem")
            {

                writer.WriteLine("" + userChoice);
                writer.Flush();
                string jsonViewitemDTO = reader.ReadLine();
                List<ItemGridDTO> itemlist = JsonSerializer.Deserialize<List<ItemGridDTO>>(jsonViewitemDTO);
                ViewItemWindow viewItemWindow = (ViewItemWindow)window;

                viewItemWindow.Dispatcher.Invoke(() =>
                {

                    viewItemWindow.dgViewItems.ItemsSource = itemlist;
                });
            }


            else if (userChoice == "AddQuantity")
            {
                writer.WriteLine("" + userChoice);
                writer.WriteLine(broadcastMessage);
                writer.Flush();

            }
            
            else if (userChoice == "RemoveQuantity")
            {
                writer.WriteLine("" + userChoice);
                writer.WriteLine(broadcastMessage);
                writer.Flush();
            }
            else if (userChoice == "ViewTransaction")
            {
                writer.WriteLine("" + userChoice);
                writer.Flush();
                string jsonviewFinancial = reader.ReadLine();

                List<TransactionViewModel> itemlist1 = JsonSerializer.Deserialize<List<TransactionViewModel>>(jsonviewFinancial);
                ViewTransactionWindow viewItemWindow = (ViewTransactionWindow)window;

                viewItemWindow.Dispatcher.Invoke(() =>
                {

                    viewItemWindow.dgTransaction.ItemsSource = itemlist1;
                });


            }
            else if (userChoice == "ViewPersonal")
            {
                writer.WriteLine("" + userChoice);
                writer.WriteLine(broadcastMessage);
                writer.Flush();

                string jsonviewPersonal = reader.ReadLine();
                List<TransactionViewModel> personalview = JsonSerializer.Deserialize<List<TransactionViewModel>>(jsonviewPersonal);
                PersonalUsageWindow personalUsageWindow = (PersonalUsageWindow)window;

                personalUsageWindow.Dispatcher.Invoke(() =>
                {

                    personalUsageWindow.dgPersonal.ItemsSource = personalview;
                });
            }
            else if (userChoice == "RapidRequest")
            {
                writer.WriteLine("" + userChoice);
                writer.WriteLine(broadcastMessage);
                writer.Flush();
            }
            else if (userChoice == "ViewFinancial")
            {
                writer.WriteLine("" + userChoice);
                
                writer.Flush();

                string jsonviewFinancial = reader.ReadLine();

                List<TransactionViewModel> itemlist = JsonSerializer.Deserialize<List<TransactionViewModel>>(jsonviewFinancial);

                double total = 0;
                string display = string.Empty;
                foreach (TransactionViewModel entry in itemlist)
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
                ViewFinancialWindow viewFinancialWindow = (ViewFinancialWindow)window;

                string totalprice = String.Format("{0}: {1:C}", "Total price of all items", total);

                viewFinancialWindow.Dispatcher.Invoke(() =>
                {

                    viewFinancialWindow.lblPrice.Content = display;
                    viewFinancialWindow.lblTotalPrice.Content = totalprice;
                });

                //lblPrice.Content = display;

               
               // lblTotalPrice.Content = totalprice;


            }




        }

        private void ReadFromServer()
        {
            //while (clientRunning)
            //{
                
            //}
                    
            
        }

        public void ReadFromServerTo()
        {

           
        }

        private void DisplayMessages()
        {
            while (clientRunning)
            {
                List<string> msgList;
                if (messages.TryDequeue(out msgList))
                {
                    DisplayBroadcastMessage(msgList);
                }
            }
        }

        public void AddCommand(string command)
        {
            commands.Add(command);
           
        }
        public void clearCommand()
        {
            
        }

        public void JsonCommand( string jsoncommand)
        {
            
            jsonCommands.Add(jsoncommand);
        }
        public void ObjectCommadnd(object objectcommand)
        {

            objectCommands.Add(objectcommand);
        }

        public void RapidRequests()
        {
            for (int i = 1; i < 201; i++)
            {
                writer.WriteLine("RapidRequest");
                writer.Flush();
                Task.Yield();
            }
        }


    }
}
