using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Views;

namespace NavigateApp.ViewModel
{
    public class PageThreeViewModel:ViewModelBase
    {
        private readonly INavigationService _navigationService;
        public PageThreeViewModel(INavigationService navigationService)
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
            _navigationService.NavigateTo("PageTwo4");
        }
    }
}