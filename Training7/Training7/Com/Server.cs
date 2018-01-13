using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Training7.Com
{
    class Server
    {
        Action<string, string> GuiInformer;
        Action<string> ClientInformer;
        Socket serverSocket;
        const int port = 10102;
        Thread acceptingThread;
        List<ClientHandler> Clients;


        public Server(Action<string, string> GuiInformer, Action<string> ClientInformer)
        {
            this.GuiInformer = GuiInformer;
            this.ClientInformer = ClientInformer;

            Clients = new List<ClientHandler>();
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                serverSocket.Bind(new IPEndPoint(IPAddress.Parse("127.0.0.2"),port));
                serverSocket.Listen(10);
                StartAccepting();
            }
            catch (Exception)
            {
                serverSocket.Close();
            }

        }

        private void StartAccepting()
        {
            acceptingThread = new Thread(Accept);
            acceptingThread.IsBackground = true;
            acceptingThread.Start();
        }

        private void Accept()
        {
            while (acceptingThread.IsAlive)
            {
                Clients.Add(new ClientHandler(serverSocket.Accept(), UpdateGui, ClientInformer));
            }
        }

        private void UpdateGui(string sender, string newMsg)
        {
            GuiInformer(sender, newMsg);
        }
    }
}
