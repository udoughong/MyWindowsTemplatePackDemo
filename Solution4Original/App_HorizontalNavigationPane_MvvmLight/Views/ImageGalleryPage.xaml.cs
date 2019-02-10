﻿using System;

using App_HorizontalNavigationPane_MvvmLight.ViewModels;

using Windows.UI.Xaml.Controls;

namespace App_HorizontalNavigationPane_MvvmLight.Views
{
    public sealed partial class ImageGalleryPage : Page
    {
        private ImageGalleryViewModel ViewModel
        {
            get { return ViewModelLocator.Current.ImageGalleryViewModel; }
        }

        public ImageGalleryPage()
        {
            InitializeComponent();
        }
    }
}
