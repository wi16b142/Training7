using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training7.ViewModel
{
    public class ClientVM:ViewModelBase
    {
        private string userID;
        private ObservableCollection<string> orders;

        public ClientVM(string userID)
        {
            UserID = userID;
            Orders = new ObservableCollection<string>();
        }

        public ObservableCollection<string> Orders
        {
            get { return orders; }
            set { orders = value; RaisePropertyChanged(); }
        }


        public string UserID
        {
            get { return userID; }
            set { userID = value; }
        }


    }
}
