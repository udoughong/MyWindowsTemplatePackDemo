using System;

using App_NavigationPane_Prism_MediaPlayer.ViewModels;

using Windows.UI.Xaml.Controls;

namespace App_NavigationPane_Prism_MediaPlayer.Views
{
    public sealed partial class MediaPlayerPage : Page
    {
        private MediaPlayerViewModel ViewModel => DataContext as MediaPlayerViewModel;

        public MediaPlayerPage()
        {
            InitializeComponent();
            ViewModel.Initialize(mpe);
        }
    }
}
