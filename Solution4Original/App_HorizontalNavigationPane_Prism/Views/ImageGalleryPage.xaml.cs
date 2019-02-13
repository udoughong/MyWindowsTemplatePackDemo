using System;

using App_HorizontalNavigationPane_Prism.ViewModels;

using Windows.UI.Xaml.Controls;

namespace App_HorizontalNavigationPane_Prism.Views
{
    public sealed partial class ImageGalleryPage : Page
    {
        private ImageGalleryViewModel ViewModel => DataContext as ImageGalleryViewModel;

        public ImageGalleryPage()
        {
            InitializeComponent();
        }
    }
}
