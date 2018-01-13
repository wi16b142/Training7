using ClientApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientApp
{
    class Program
    {
        private static Client client;
        private static int i = 1;

        static void Main(string[] args)
        {
            DataGenerator datagen = new DataGenerator(PlaceOrder);
            client = new Client(ReceiveMsg);

            Console.WriteLine("Welcome to ProductionOrder Generator by Sascha Böck");
            Console.WriteLine("Generator initiated");

            if (client.ClientSocket.Connected)
            {
                Console.WriteLine("Connection to server established, begin sending orders.");
                datagen.StartGenerating();
            } 
    
            Console.ReadLine();
        }

        static private void ReceiveMsg(string msg)
        {
            Console.WriteLine(msg);
            //optional receive msg
        }

        static private void PlaceOrder(string order)
        {
            Console.WriteLine("Sending Order "+i+":"+order);
            i++;
            client.Send(order);
        }
    }
}
