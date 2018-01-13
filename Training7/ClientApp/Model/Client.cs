using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ClientApp.Model
{
    public class Client
    {
        int port = 10102;
        Action<string> ReceiveMsg;
        Socket clientSocket;
        byte[] buffer = new byte[512];

        public Socket ClientSocket { get => clientSocket; private set => clientSocket = value; }

        public Client(Action<string> ReceiveMsg)
        {
            this.ReceiveMsg = ReceiveMsg;
            TcpClient client = new TcpClient();
            client.Connect(IPAddress.Parse("127.0.0.2"), port);
            ClientSocket = client.Client;
            StartReceiving();
        }

        public void Send(string msg)
        {
            ClientSocket.Send(Encoding.UTF8.GetBytes(msg));
        }

        private void StartReceiving()
        {
            Task.Factory.StartNew(Receive);
        }

        private void Receive()
        {
            while (true)
            {
                int length = ClientSocket.Receive(buffer);
                string msg = Encoding.UTF8.GetString(buffer,0,length);
                ReceiveMsg(msg);
            }
        }
    }
}
