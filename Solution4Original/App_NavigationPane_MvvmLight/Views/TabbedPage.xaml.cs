using System;

using App_NavigationPane_MvvmLight.ViewModels;

using Windows.UI.Xaml.Controls;

namespace App_NavigationPane_MvvmLight.Views
{
    public sealed partial class TabbedPage : Page
    {
        private TabbedViewModel ViewModel
        {
            get { return ViewModelLocator.Current.TabbedViewModel; }
        }

        public TabbedPage()
        {
            InitializeComponent();
        }
    }
}
