using System;

using _App_NavigationPane_MvvmBasic_MediaPlayer.ViewModels;

using Windows.UI.Xaml.Controls;

namespace _App_NavigationPane_MvvmBasic_MediaPlayer.Views
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
