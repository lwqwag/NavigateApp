using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Views;

namespace NavigateApp.ViewModel
{
    public class PageFourViewModel
    {
        private readonly INavigationService _navigationService;
        public PageFourViewModel(INavigationService navigationService)
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
            _navigationService.NavigateTo("PageFour");
        }
    }
}