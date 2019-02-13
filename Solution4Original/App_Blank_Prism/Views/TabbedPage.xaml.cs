using System;

using App_Blank_Prism.ViewModels;

using Windows.UI.Xaml.Controls;

namespace App_Blank_Prism.Views
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
