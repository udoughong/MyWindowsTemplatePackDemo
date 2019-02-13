﻿using System;

using App_HorizontalNavigationPane_Prism.ViewModels;

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace App_HorizontalNavigationPane_Prism.Views
{
    public sealed partial class ImageGalleryDetailPage : Page
    {
        public ImageGalleryDetailViewModel ViewModel => DataContext as ImageGalleryDetailViewModel;

        public ImageGalleryDetailPage()
        {
            InitializeComponent();
        }

        private void OnPageKeyDown(object sender, KeyRoutedEventArgs e)
        {
            ViewModel.HandleKeyDown(e);
        }
    }
}
