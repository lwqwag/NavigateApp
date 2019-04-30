/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:NavigateApp"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using System;
using System.Windows.Navigation;
using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;

namespace NavigateApp.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<PageOneViewModel>();
            SimpleIoc.Default.Register<PageTwoViewModel>();
            SimpleIoc.Default.Register<PageThreeViewModel>();
            SimpleIoc.Default.Register<PageFourViewModel>();
            var navigationService = CreateNavigationService();
            SimpleIoc.Default.Register(() => navigationService);
        }
        private static INavigationService CreateNavigationService()
        {
            
            var navigationService = new NavigationService();
            navigationService.Configure("PageTwo1", new Uri("/NavigateApp;component/Views/PageOne.xaml", UriKind.Relative));
            navigationService.Configure("PageTwo2", new Uri("/NavigateApp;component/Views/PageTwo.xaml", UriKind.Relative));
            navigationService.Configure("PageTwo3", new Uri("/NavigateApp;component/Views/PageThree.xaml", UriKind.Relative));
            navigationService.Configure("PageTwo4", new Uri("/NavigateApp;component/Views/PageFour.xaml", UriKind.Relative));
            return navigationService;
        }
        public MainViewModel Main => ServiceLocator.Current.GetInstance<MainViewModel>();
        public PageOneViewModel PageOne => ServiceLocator.Current.GetInstance<PageOneViewModel>();

        public PageFourViewModel PageFour => ServiceLocator.Current.GetInstance<PageFourViewModel>();
        public PageThreeViewModel PageThree => ServiceLocator.Current.GetInstance<PageThreeViewModel>();
        public PageTwoViewModel PageTwo => ServiceLocator.Current.GetInstance<PageTwoViewModel>();
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}