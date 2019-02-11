using System;

using App_NavigationPane_Prism.Core.Models;
using App_NavigationPane_Prism.ViewModels;

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace App_NavigationPane_Prism.Views
{
    public sealed partial class ContentGridDetailPage : Page
    {
        public ContentGridDetailPage()
        {
            InitializeComponent();
        }

        private ContentGridDetailViewModel ViewModel => DataContext as ContentGridDetailViewModel;
    }
}
