using System;

using App_Blank_MvvmLight.ViewModels;

using Windows.UI.Xaml.Controls;

namespace App_Blank_MvvmLight.Views
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
