using System;

using App_NavigationPane_CaliburnMicro.ViewModels;

using Windows.UI.Xaml.Controls;

namespace App_NavigationPane_CaliburnMicro.Views
{
    public sealed partial class TabbedPage : Page
    {
        public TabbedPage()
        {
            InitializeComponent();
        }

        private TabbedViewModel ViewModel
        {
            get { return DataContext as TabbedViewModel; }
        }
    }
}
