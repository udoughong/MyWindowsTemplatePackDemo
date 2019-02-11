using System;

using App_HorizontalNavigationPane_CaliburnMicro.ViewModels;

using Windows.UI.Xaml.Controls;

namespace App_HorizontalNavigationPane_CaliburnMicro.Views
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private MainViewModel ViewModel
        {
            get { return DataContext as MainViewModel; }
        }
    }
}
