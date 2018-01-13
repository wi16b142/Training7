using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClientApp.Model
{
    public class DataGenerator
    {
        static Random rnd = new Random();
        static string[] blueprints = new string[] { "Car{Engine;Tires;Centrer;Gear}", "Motorcycle{Engine;Tires;Chassis;Tank}", "Bicycle{Rack;Tires;Pedals}" };
        string id = "";
        Thread generatingThread;
        Action<string> PlaceOrder;

        public string Id { get => id; set => id = value; }

        public DataGenerator(Action<string> PlaceOrder)
        {
            Id = "user" + rnd.Next(0,1000).ToString();
            this.PlaceOrder = PlaceOrder;
        }

        public void StartGenerating()
        {
            generatingThread = new Thread(Generate);
            generatingThread.IsBackground = true;
            generatingThread.Start();
        }

        private void Generate()
        {
            while (generatingThread.IsAlive)
            {
                PlaceOrder(Id + "@" + blueprints[rnd.Next(0, 2)] + rnd.Next(1, 100).ToString() + ";" + rnd.Next(00, 23).ToString() + ":" + rnd.Next(00, 59).ToString());
                Thread.Sleep(5000);
            }
        }

        public void StopGenerating()
        {
            generatingThread.Abort();
        }
    }
}
