﻿using System;

using App_NavigationPane_MvvmLight.ViewModels;

using Windows.UI.Xaml.Controls;

namespace App_NavigationPane_MvvmLight.Views
{
    public sealed partial class WebViewPage : Page
    {
        private WebViewViewModel ViewModel
        {
            get { return ViewModelLocator.Current.WebViewViewModel; }
        }

        public WebViewPage()
        {
            InitializeComponent();
            ViewModel.Initialize(webView);
        }
    }
}
