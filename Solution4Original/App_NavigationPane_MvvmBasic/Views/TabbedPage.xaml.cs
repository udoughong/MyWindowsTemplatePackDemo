using System;

using App_NavigationPane_MvvmBasic.ViewModels;

using Windows.UI.Xaml.Controls;

namespace App_NavigationPane_MvvmBasic.Views
{
    public sealed partial class TabbedPage : Page
    {
        public TabbedViewModel ViewModel { get; } = new TabbedViewModel();

        public TabbedPage()
        {
            InitializeComponent();
        }
    }
}
