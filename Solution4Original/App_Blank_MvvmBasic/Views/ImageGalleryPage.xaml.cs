using System;

using App_Blank_MvvmBasic.ViewModels;

using Windows.UI.Xaml.Controls;

namespace App_Blank_MvvmBasic.Views
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
