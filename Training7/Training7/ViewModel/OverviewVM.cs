using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training7.ViewModel
{
    public class OverviewVM:ViewModelBase
    {

        private ObservableCollection<OrderVM> orders;
        private OrderVM selectedOrder;

        public OrderVM SelectedOrder
        {
            get { return selectedOrder; }
            set { selectedOrder = value; RaisePropertyChanged(); }
        }

        Messenger messenger = SimpleIoc.Default.GetInstance<Messenger>();
        public ObservableCollection<OrderVM> Orders
        {
            get { return orders; }
            set { orders = value; RaisePropertyChanged(); }
        }

        public OverviewVM()
        {
            Orders = new ObservableCollection<OrderVM>();
            messenger.Register<PropertyChangedMessage<OrderVM>>(this, NewOrder);
        }

        private void NewOrder(PropertyChangedMessage<OrderVM> obj)
        {
            App.Current.Dispatcher.Invoke(()=> 
            {
                Orders.Add(obj.NewValue);
            });
            
        }

        //subscribe to messenger
        //add OrderVM from msg to observable
        //selected OrderVM


    }
}
