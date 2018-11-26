using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;

namespace UDPProxy
{
    public class Proxy
    {
        private const string BASEURI = "http://localhost:55884/api/Sensors";
        private readonly int PORT;

        public Proxy(int port)
        {
            PORT = port;
        }

        public void Start()
        {
            IPEndPoint removeEP = new IPEndPoint(IPAddress.Any, PORT);

            using (UdpClient receiverSocket = new UdpClient(PORT))
            {
                while (true)
                {                    
                    Post(HandleOneRequest(receiverSocket, removeEP));
                }
            }
        }

        private string HandleOneRequest(UdpClient receiverSocket, IPEndPoint removeEP)
        {
            byte[] data = receiverSocket.Receive(ref removeEP);
            string inString = Encoding.ASCII.GetString(data);

            return inString;
        }

        private static bool Post(string jsonString)
        {
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                HttpResponseMessage response = client.PostAsync(BASEURI, content).Result;

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                return false;

            }
        }
    }
}
