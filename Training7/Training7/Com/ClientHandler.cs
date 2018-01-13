using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Training7.Com
{
    class ClientHandler
    {
        Socket clientSocket;
        Action<string> ClientInformer;
        Action<string, string> NewMsg;
        Thread receivingThread;
        byte[] buffer = new byte[512];
        string userID = "";

        public ClientHandler(Socket accepted,  Action<string, string> NewMsg, Action<string> ClientInformer)
        {
            this.clientSocket = accepted;
            this.ClientInformer = ClientInformer;
            this.NewMsg = NewMsg;

            StartReceiving();
        }

        private void StartReceiving()
        {
            receivingThread = new Thread(Receive);
            receivingThread.IsBackground = true;
            receivingThread.Start();
        }

        private void Receive()
        {
            while (receivingThread.IsAlive)
            {

                int length = clientSocket.Receive(buffer);
                string msg = Encoding.UTF8.GetString(buffer, 0, length);

                if(userID == "")
                {
                    userID = msg.Split('@')[0];
                    ClientInformer(userID);
                }

                NewMsg(userID, msg.Split('@')[1]);
            }
        }
    }
}
