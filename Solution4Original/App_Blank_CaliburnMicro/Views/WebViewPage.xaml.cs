using System;

using App_Blank_CaliburnMicro.ViewModels;

using Windows.UI.Xaml.Controls;

namespace App_Blank_CaliburnMicro.Views
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
