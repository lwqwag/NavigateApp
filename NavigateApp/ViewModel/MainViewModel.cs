using System;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Views;

namespace NavigateApp.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            Messenger.Default.Register<string>("Load", "Loaded", p =>
            {
                _navigationService.NavigateTo("PageTwo1");

            });
        }

        public ICommand Next
        {
            get { return new RelayCommand(() => { _navigationService.NavigateTo("PageTwo1"); }); }
        }

        public ICommand ToPageOneCommand
        {
            get { return new RelayCommand(() => { _navigationService.NavigateTo("PageTwo1"); }); }
        }
    }
}