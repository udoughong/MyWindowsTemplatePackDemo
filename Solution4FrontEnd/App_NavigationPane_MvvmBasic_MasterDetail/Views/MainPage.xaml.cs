using System;

using App_NavigationPane_MvvmBasic_MasterDetail.ViewModels;

using Windows.UI.Xaml.Controls;

namespace App_NavigationPane_MvvmBasic_MasterDetail.Views
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
