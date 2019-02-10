using System;

using App_HorizontalNavigationPane_MvvmLight.ViewModels;

using Windows.UI.Xaml.Controls;

namespace App_HorizontalNavigationPane_MvvmLight.Views
{
    public sealed partial class MainPage : Page
    {
        private MainViewModel ViewModel
        {
            get { return ViewModelLocator.Current.MainViewModel; }
        }

        public MainPage()
        {
            InitializeComponent();
        }
    }
}
