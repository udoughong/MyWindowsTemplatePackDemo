using System;

using App_HorizontalNavigationPane_CaliburnMicro.ViewModels;

using Windows.UI.Xaml.Controls;

namespace App_HorizontalNavigationPane_CaliburnMicro.Views
{
    public sealed partial class ImageGalleryPage : Page
    {
        public ImageGalleryPage()
        {
            InitializeComponent();
        }

        private ImageGalleryViewModel ViewModel
        {
            get { return DataContext as ImageGalleryViewModel; }
        }
    }
}
