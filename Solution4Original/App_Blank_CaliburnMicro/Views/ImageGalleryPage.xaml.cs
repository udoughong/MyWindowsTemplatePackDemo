using System;

using App_Blank_CaliburnMicro.ViewModels;

using Windows.UI.Xaml.Controls;

namespace App_Blank_CaliburnMicro.Views
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
