using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training7.ViewModel
{
    public class OrderVM : ViewModelBase
    {
        private string components;
        private string name;
        private int amount;
        private DateTime time;
        private string completionTime;
        private int rating;

        public OrderVM(string name, string completionTime, int amount, string compnents)
        {
            CompletionTime = completionTime;
            Amount = amount;
            Compnents = compnents;
            Time = DateTime.Now;
            Name = name;
            CalcRating();

        }

        public OrderVM()
        {
        }

        private void CalcRating()
        {
            Rating = 2;
            //calc and set rating
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Rating
        {
            get { return rating; }
            set { rating = value; }
        }


        public string CompletionTime
        {
            get { return completionTime; }
            set { completionTime = value; }
        }


        public DateTime Time
        {
            get { return time; }
            set { time = value; }
        }


        public int Amount
        {
            get { return amount; }
            set { amount = value; }
        }


        public string Compnents
        {
            get { return components; }
            set { components = value; }
        }


    }
}
