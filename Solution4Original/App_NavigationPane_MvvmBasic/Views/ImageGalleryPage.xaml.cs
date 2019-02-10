using System;

using App_NavigationPane_MvvmBasic.ViewModels;

using Windows.UI.Xaml.Controls;

namespace App_NavigationPane_MvvmBasic.Views
{
    public sealed partial class ImageGalleryPage : Page
    {
        public ImageGalleryViewModel ViewModel { get; } = new ImageGalleryViewModel();

        public ImageGalleryPage()
        {
            InitializeComponent();
        }
    }
}
