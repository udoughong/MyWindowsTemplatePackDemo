using System;

using App_NavigationPane_Prism.ViewModels;

using Windows.UI.Xaml.Controls;

namespace App_NavigationPane_Prism.Views
{
    public sealed partial class TabbedPage : Page
    {
        private TabbedViewModel ViewModel => DataContext as TabbedViewModel;

        public TabbedPage()
        {
            InitializeComponent();
        }
    }
}
