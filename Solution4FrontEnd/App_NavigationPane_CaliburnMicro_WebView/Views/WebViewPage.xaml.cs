﻿using System;

using App_NavigationPane_CaliburnMicro_WebView.ViewModels;

using Windows.UI.Xaml.Controls;

namespace App_NavigationPane_CaliburnMicro_WebView.Views
{
    public sealed partial class WebViewPage : Page
    {
        public WebViewPage()
        {
            InitializeComponent();

            Loaded += (s, e) => ViewModel.Initialize(webView);
        }

        private WebViewViewModel ViewModel
        {
            get { return DataContext as WebViewViewModel; }
        }
    }
}
