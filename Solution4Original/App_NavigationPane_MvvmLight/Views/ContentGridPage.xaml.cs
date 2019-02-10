using System;

using App_NavigationPane_MvvmLight.ViewModels;

using Windows.UI.Xaml.Controls;

namespace App_NavigationPane_MvvmLight.Views
{
    public sealed partial class ContentGridPage : Page
    {
        private ContentGridViewModel ViewModel
        {
            get { return ViewModelLocator.Current.ContentGridViewModel; }
        }

        public ContentGridPage()
        {
            InitializeComponent();
        }
    }
}
