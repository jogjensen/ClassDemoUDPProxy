using System;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using Newtonsoft.Json;
using SensorModelLib.model;

namespace ClassDemoUDPProxy
{
    class ProxyWorker
    {
        private const string URI = "http://localhost:51404/api/Sensor/";

        private readonly UdpClient client = new UdpClient(10100); // modtage pakker på 10100 port nummer
        private byte[] buffer;


        public ProxyWorker()
        {
        }

        public async void Start()
        {
            while (true)
            {
                SensorData obj = ReadUDPPacket();
                SendToRest(obj);
            }

        }


        public SensorData ReadUDPPacket()
        {
            // udp - Receive
            IPEndPoint remoteEP = new IPEndPoint(IPAddress.Any, 0);
            buffer = client.Receive(ref remoteEP);

            string jsonstr = Encoding.UTF8.GetString(buffer);
            Console.WriteLine("tekst modtaget = " + jsonstr);

            return JsonConvert.DeserializeObject<SensorData>(jsonstr);
        }

        public async void SendToRest(SensorData obj)
        {
            // http client - PostAsync
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(
                    JsonConvert.SerializeObject(obj),Encoding.UTF8,"application/json");

                HttpResponseMessage resp = await client.PostAsync(URI, content);
                //if (resp.IsSuccessStatusCode)
                //{
                //    return;
                //}

                //throw new ArgumentException("opret fejlede");
            }

        }
    }

    
}