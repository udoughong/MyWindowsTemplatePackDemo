using System;

using App_Blank_MvvmBasic.ViewModels;

using Windows.UI.Xaml.Controls;

namespace App_Blank_MvvmBasic.Views
{
    public sealed partial class WebViewPage : Page
    {
        public WebViewViewModel ViewModel { get; } = new WebViewViewModel();

        public WebViewPage()
        {
            InitializeComponent();
            ViewModel.Initialize(webView);
        }
    }
}
