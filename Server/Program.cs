using Server;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Server has started!");
        MyServer srvr = new MyServer();

        srvr.Start(); 

        srvr.Stop();

        Console.WriteLine("Server has finished!");
    }
}
