using System;

using App_NavigationPane_CaliburnMicro.Core.Models;
using App_NavigationPane_CaliburnMicro.Core.Services;
using App_NavigationPane_CaliburnMicro.ViewModels;

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace App_NavigationPane_CaliburnMicro.Views
{
    public sealed partial class ImageGalleryDetailPage : Page
    {
        public ImageGalleryDetailPage()
        {
            InitializeComponent();
        }

        private ImageGalleryDetailViewModel ViewModel
        {
            get { return DataContext as ImageGalleryDetailViewModel; }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            ViewModel.Initialize(e.NavigationMode);
        }

        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            base.OnNavigatingFrom(e);
            if (e.NavigationMode == NavigationMode.Back)
            {
                ViewModel.UpdateConnectedAnimation();
            }
        }
    }
}
