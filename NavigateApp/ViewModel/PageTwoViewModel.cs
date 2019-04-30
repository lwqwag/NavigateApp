using System.Windows.Input;
using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Views;

namespace NavigateApp.ViewModel
{
    public class PageTwoViewModel: ViewModelBase
    {
        private readonly INavigationService _navigationService;
        public PageTwoViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }
        public ICommand GoToNextCommand => new RelayCommand(GotoNext);
        public ICommand GoToPreviousCommand => new RelayCommand(() =>
        {
            _navigationService.GoBack();
        });
        private void GotoNext()
        {
            _navigationService.NavigateTo("PageTwo3");
        }
    }
}