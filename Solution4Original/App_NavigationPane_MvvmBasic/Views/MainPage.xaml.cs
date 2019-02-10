using System;

using App_NavigationPane_MvvmBasic.ViewModels;

using Windows.UI.Xaml.Controls;

namespace App_NavigationPane_MvvmBasic.Views
{
    public sealed partial class MainPage : Page
    {
        public MainViewModel ViewModel { get; } = new MainViewModel();

        public MainPage()
        {
            InitializeComponent();
        }
    }
}
