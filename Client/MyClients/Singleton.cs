using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.MyClients
{
    public delegate void DisplayBroadcastMessage(List<string> msg);
    public delegate void DisplayVerse(List<string> verse);
    public delegate string GetMessageToBroadcast();
    public delegate void ShowMessage(string msg);

    public sealed class MyWPFClientSingleton
    {
        private static readonly MyWPFClient instance = new MyWPFClient(AppendBroadcastMessage, GetMessageToBroadcast, ShowMessage, DisplayVerse);

        private MyWPFClientSingleton() { }

        public static MyWPFClient Instance
        {
            get
            {
                return instance;
            }
        }

        public static void AppendBroadcastMessage(List<string> msg)
        {
            // msg.ForEach(s => Dispatcher.Invoke(() => BroadcastArea.Text += s));
            //Dispatcher.Invoke(() => BroadcastArea.ScrollToEnd());
        }

        public static string GetMessageToBroadcast()
        {
            // return Dispatcher.Invoke(() => MessageToBroadcast.Text);
            return String.Empty;
        }

        public static void ShowMessage(string msg)
        {
           // MessageBox.Show(msg);
        }

        public static void DisplayVerse(List<string> verse)
        {
            //Dispatcher.Invoke(() => DisplayArea.Text = "");
            //verse.ForEach(s => Dispatcher.Invoke(() => DisplayArea.Text += s + "\n"));
        }
    }
}
