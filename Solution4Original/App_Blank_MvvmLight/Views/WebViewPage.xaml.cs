using System;

using App_Blank_MvvmLight.ViewModels;

using Windows.UI.Xaml.Controls;

namespace App_Blank_MvvmLight.Views
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
