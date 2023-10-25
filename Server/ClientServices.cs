using Server.CommandLineUI.Presenter;
using Server.Controller;
using Server.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text.Json;

namespace Server
{
    class ClientService
    {

        private Socket socket;
        private NetworkStream stream;
        public StreamReader reader { get; private set; }
        public StreamWriter writer { get; private set; }

        private RemoveClient removeMe;

        private BroadcastMessageToAllClients broadcast;
        private MessageToAllClients message;

        public ClientService(Socket socket, RemoveClient rc, BroadcastMessageToAllClients broadcast, MessageToAllClients message)
        {
            this.socket = socket;
            removeMe = rc;
            this.broadcast = broadcast;
            

            stream = new NetworkStream(socket);
            reader = new StreamReader(stream, System.Text.Encoding.UTF8);
            writer = new StreamWriter(stream, System.Text.Encoding.UTF8);
            this.message = message;
        }
        public void InteractWithClient()
        {
            try
            {
                string command = reader.ReadLine();
                while (command != null)
                {
                    ProcessClientMessage(command);

                    switch (command)
                    {
                        case "AddItem":
                            string json = reader.ReadLine();
                            ItemViewModel itemvm = JsonSerializer.Deserialize<ItemViewModel>(json);

                            AddItemController controller =
                  new AddItemController(
                      itemvm.employeeName,
                     itemvm.itemID,
                      itemvm.itemName,
                     itemvm.itemQuantity,
                      itemvm.itemPrice,
                      new MessagePresenter());


                            CommandLineViewData data =
                           (CommandLineViewData)controller.Execute();

                            Console.WriteLine("Succesfully New Item Added");

                            break;

                        case "ViewItem":

                            ViewInventoryController controller2 =
                    new ViewInventoryController(
                            new MessagePresenter());

                            var viewItem =
                                controller2.ExecuteGrid();

                            string jsonviewItem = JsonSerializer.Serialize(viewItem);

                           
                            broadcast(jsonviewItem);
                            break;

                        case "AddQuantity":
                            string jsonAdd = reader.ReadLine();
                            TransactionViewModel transactionViewModel = JsonSerializer.Deserialize<TransactionViewModel>(jsonAdd);


                            AddQuantityContoller controllerQuantity =
                   new AddQuantityContoller(
                       transactionViewModel.EmployeeName,
                      transactionViewModel.ItemID,
                     transactionViewModel.Quantity,
                       transactionViewModel.ItemPrice,
                       new MessagePresenter());

                            CommandLineViewData data1 =
                           (CommandLineViewData)controllerQuantity.Execute();



                            Console.WriteLine("Succesfully Quantity Added");
                           
                            break;

                        case "RemoveQuantity":
                            string jsonRemove = reader.ReadLine();
                            TransactionViewModel transactionViewModel1 = JsonSerializer.Deserialize<TransactionViewModel>(jsonRemove);


                            RemoveQuantityController controllerRemove =
                   new RemoveQuantityController(
                       transactionViewModel1.EmployeeName,
                      transactionViewModel1.ItemID,
                     transactionViewModel1.Quantity,
                       new MessagePresenter());

                            CommandLineViewData data2 =
                           (CommandLineViewData)controllerRemove.Execute();


                            Console.WriteLine("Succesfully Quantity Removed");
                            break;

                        case "ViewTransaction":
                            ViewTransactionController controllerViewTransaction =
                   new ViewTransactionController(
                       new MessagePresenter());


                            var viewTransaction =
                                controllerViewTransaction.TransactionLogs();

                            string jsonviewTransaction = JsonSerializer.Serialize(viewTransaction);

                            //writer.WriteLine(jsonviewTransaction);
                            broadcast(jsonviewTransaction);
                            break;

                        case "ViewPersonal":
                            string jsonPersonal = reader.ReadLine();
                            TransactionViewModel transactionViewModel2 = JsonSerializer.Deserialize<TransactionViewModel>(jsonPersonal);
                            
                            PersonalController controllerPersonal =
                 new PersonalController(
                    transactionViewModel2.EmployeeName,
                     new MessagePresenter());



                            var personal =
                            controllerPersonal.ExecutePersonalUsage();

                            string viewPersonal = JsonSerializer.Serialize(personal);

                           
                            broadcast(viewPersonal);


                            break;

                        case "ViewFinancial":

                            ViewFinancialReportController viewFinancialReportController =
                    new ViewFinancialReportController(
                        new MessagePresenter());

                            var data3 = viewFinancialReportController.ExecuteUseCaseFinancial();

                            string jsonviewFinancial = JsonSerializer.Serialize(data3);

                            broadcast(jsonviewFinancial);
                            break;
                       
                        case "RapidRequest":
                            string jsonrapid = reader.ReadLine();
                            Console.WriteLine("Rapid Request " + jsonrapid);
                            
                            break;
                        default:
                            //Console.WriteLine("Invalid command: " + command);

                            break;

                        
                    }

                    command = reader.ReadLine();
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("ERROR: " + e.Message);
            }

            Console.WriteLine("Goodbye from " + socket.RemoteEndPoint.ToString());
            Close();
        }

        private void ProcessClientMessage(string clientMessage)
        {
            Console.WriteLine("Client says: " + clientMessage);
            
        }

        public void Close()
        {
            try
            {
                removeMe(this);
                socket.Shutdown(SocketShutdown.Both);
            }
            finally
            {
                socket.Close();
            }
        }

        public void BroadCastMessage(string message)
        {

            lock (writer)
            {
                writer.WriteLine(message);
                writer.Flush();
            }
        }

        public void Message(string message)
        {

            lock (writer)
            {
              
                writer.Flush();
               
            }
        }
    }
}
        
    
