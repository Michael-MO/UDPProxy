using System;

namespace UDPProxy
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Proxy prox = new Proxy(12121);
            prox.Start();

            Console.ReadLine();
        }
    }
}
