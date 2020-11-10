namespace ClassDemoUDPProxy
{
    class ProxyWorker
    {
        public ProxyWorker()
        {
        }

        public async void Start()
        {
            while (true)
            {
                SomeClass obj = ReadUDPPacket();
                SendToRest(obj);
            }

        }


        public SomeClass ReadUDPPacket()
        {
            // udp - Receive

            return null;
        }

        public async void SendToRest(SomeClass obj)
        {
            // http client - PostAsync

        }
    }

    // dummy
    class SomeClass
    {

    }
}