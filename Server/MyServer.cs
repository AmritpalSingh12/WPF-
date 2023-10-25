using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using Server;
using Server.CommandLineUI;
using Server.CommandLineUI.Commands;
using Server.CommandLineUI.Menu;

namespace Server
{
    delegate void RemoveClient(ClientService c);
    delegate void BroadcastMessageToAllClients(string message);
    delegate void MessageToAllClients(string message);

    class MyServer
    {
        private TcpListener tcpListener;
        private List<ClientService> clientServices;

        public MyServer()
        {
            IPAddress ipAddress = IPAddress.Loopback;
            tcpListener = new TcpListener(ipAddress, 4444);
            clientServices = new List<ClientService>();
            Console.WriteLine("Listening....");
        }

        public void Start()
        {
            CommandFactory factory = new CommandFactory();
            try
            {
                factory
                    .CreateCommand(RequestUseCase.INITIALISE_DATABASE)
                    .Execute();

               
              
            }
            catch (Exception e)
            {
                Console.WriteLine("\nERROR: " + e.Message);
            }

            tcpListener.Start();

           
            Timer t = new Timer(BroadcastTime);
            t.Change(3000, 5000);

            while (true)
            {
                Socket s = tcpListener.AcceptSocket();  
                ClientService clientService = new ClientService(s, RemoveClient, BroadcastMessage, Message);
                clientServices.Add(clientService);
                Task.Run(clientService.InteractWithClient);
            }
        }

        public void Stop()
        {
            tcpListener.Stop();
        }

        private void RemoveClient(ClientService c)
        {
            Console.WriteLine("REMOVING CLIENT");
            clientServices.Remove(c);
        }

        private void BroadcastTime(object state)
        {
            string msg = string.Format(
                         "{0}: The time is {1}",
                         tcpListener.LocalEndpoint.ToString(),
                         DateTime.Now.ToString("HH:mm:ss"));
            Message(msg);
            //Console.WriteLine("BROADCASTING: " + msg);
        }

        private void BroadcastMessage(string msg)
        {
            if (clientServices.Count > 0)
            {
               Console.WriteLine("BROADCASTING: " + msg);
                clientServices.ForEach(c => c.BroadCastMessage(msg));
            }
            else
            {
                Console.WriteLine("NOT BROADCASTING BECAUSE NO CLIENTS");
            }
        }

        private void Message(string msg)
        {
            if (clientServices.Count > 0)
            {
                Console.WriteLine("BROADCASTING: " + msg);
                clientServices.ForEach(c => c.Message(msg));
            }
            else
            {
                Console.WriteLine("NOT BROADCASTING BECAUSE NO CLIENTS");
            }
        }

    }
}
