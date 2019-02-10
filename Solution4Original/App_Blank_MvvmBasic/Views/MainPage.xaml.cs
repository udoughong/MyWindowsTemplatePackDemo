using System;

using App_Blank_MvvmBasic.ViewModels;

using Windows.UI.Xaml.Controls;

namespace App_Blank_MvvmBasic.Views
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
