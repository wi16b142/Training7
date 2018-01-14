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
        private string completionTimeString;
        private DateTime completionTime;
        private int rating;

        public OrderVM(string name, string completionTime, int amount, string compnents)
        {
            completionTimeString = completionTime;
            Amount = amount;
            Compnents = compnents;
            Time = DateTime.Now;
            Name = name;
            ConvertCompletionTimeStringToDateTime();
            CalcRating();

        }

        public OrderVM()
        {

        }

        private void ConvertCompletionTimeStringToDateTime()
        {
            int hour, min;
            TimeSpan tempTs;

            hour = int.Parse(completionTimeString.Split(':')[0]);
            min = int.Parse(completionTimeString.Split(':')[1]);
            tempTs = new TimeSpan(hour, min, 0);
            completionTime = DateTime.Now;
            completionTime = completionTime.Date + tempTs;
        }

        private void CalcRating()
        {
            TimeSpan ts = completionTime - time;

            Rating = 0;

            if (ts.Hours >= 1)
            {
                Rating = ts.Hours; 
            }
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

        public DateTime CompletionTime { get => completionTime; set => completionTime = value; }
    }
}
