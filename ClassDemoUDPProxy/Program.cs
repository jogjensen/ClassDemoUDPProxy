using System;

namespace ClassDemoUDPProxy
{
    class Program
    {
        static void Main(string[] args)
        {
            ProxyWorker worker = new ProxyWorker();
            worker.Start();

            Console.ReadLine();
            Console.WriteLine("Hello World!");
        }
    }
}
