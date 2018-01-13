using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Ioc;

namespace Training7.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public RelayCommand ComBtnClick { get; set; }
        public RelayCommand DataBtnClick { get; set; }
        public RelayCommand OverviewBtnClick { get; set; }
        private ViewModelBase currentView;
        public ViewModelBase CurrentView
        {
            get { return currentView; }
            set { currentView = value; RaisePropertyChanged(); }
        }

        public MainViewModel()
        {
            CurrentView = SimpleIoc.Default.GetInstance<OverviewVM>();

            ComBtnClick = new RelayCommand(()=> 
            {
                CurrentView = SimpleIoc.Default.GetInstance<ComVM>();
            });

            DataBtnClick = new RelayCommand(() =>
            {
                CurrentView = SimpleIoc.Default.GetInstance<DataVM>();
            });

            OverviewBtnClick = new RelayCommand(() =>
            {
                CurrentView = SimpleIoc.Default.GetInstance<OverviewVM>();
            });
        }
    }
}