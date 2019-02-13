using System;

using _App_NavigationPane_MvvmBasic_MediaPlayer.ViewModels;

using Windows.UI.Xaml.Controls;

namespace _App_NavigationPane_MvvmBasic_MediaPlayer.Views
{
    // TODO WTS: Change the icons and titles for all NavigationViewItems in ShellPage.xaml.
    public sealed partial class ShellPage : Page
    {
        public ShellViewModel ViewModel { get; } = new ShellViewModel();

        public ShellPage()
        {
            InitializeComponent();
            DataContext = ViewModel;
            ViewModel.Initialize(shellFrame, navigationView, KeyboardAccelerators);
        }
    }
}
