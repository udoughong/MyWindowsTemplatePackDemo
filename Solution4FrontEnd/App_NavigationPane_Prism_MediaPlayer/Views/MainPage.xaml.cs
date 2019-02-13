using System;

using App_NavigationPane_Prism_MediaPlayer.ViewModels;

using Windows.UI.Xaml.Controls;

namespace App_NavigationPane_Prism_MediaPlayer.Views
{
    public sealed partial class MainPage : Page
    {
        private MainViewModel ViewModel => DataContext as MainViewModel;

        public MainPage()
        {
            InitializeComponent();
        }
    }
}
