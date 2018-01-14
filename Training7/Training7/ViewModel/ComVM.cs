using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Training7.Com;

namespace Training7.ViewModel
{
    public class ComVM : ViewModelBase
    {
        Server server;
        private ObservableCollection<ClientVM> clients;
        Messenger messenger = SimpleIoc.Default.GetInstance<Messenger>();
        public RelayCommand<ClientVM> DropBtnClick { get; set; }


        public ObservableCollection<ClientVM> Clients
        {
            get { return clients; }
            set { clients = value; RaisePropertyChanged(); }
        }


        public ComVM()
        {
            server = new Server(UpdateGui, UpdateClient);
            Clients = new ObservableCollection<ClientVM>();

            DropBtnClick = new RelayCommand<ClientVM>((p)=> 
            {
                throw new NotImplementedException();
            });
        }

        private void UpdateGui(string sender, string msg)
        {
            App.Current.Dispatcher.Invoke(()=> 
            {
                string name, completionTime, components;
                int amount;
                string[] rawMsg;

                foreach(var client in Clients)
                {  
                    if (client.UserID.Equals(sender))
                    {
                        client.Orders.Add(msg);
                    }
                }

                rawMsg = msg.Split('}');
                components = rawMsg[0].Split('{')[1];
                name = rawMsg[0].Split('{')[0];
                amount = int.Parse(rawMsg[1].Split(';')[0]);
                completionTime = rawMsg[1].Split(';')[1];

                OrderVM newOrder = new OrderVM(name, completionTime, amount, components);
                messenger.Send<PropertyChangedMessage<OrderVM>>(new PropertyChangedMessage<OrderVM>(null, newOrder, ""));
            });
            
        }

        private void UpdateClient(string newUserID)
        {
            App.Current.Dispatcher.Invoke(()=> 
            {
                Clients.Add(new ClientVM(newUserID));
            });
            
        }
    }
}
