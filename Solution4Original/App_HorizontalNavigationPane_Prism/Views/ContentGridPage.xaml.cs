using System;

using App_HorizontalNavigationPane_Prism.ViewModels;

using Windows.UI.Xaml.Controls;

namespace App_HorizontalNavigationPane_Prism.Views
{
    public sealed partial class ContentGridPage : Page
    {
        private ContentGridViewModel ViewModel => DataContext as ContentGridViewModel;

        public ContentGridPage()
        {
            InitializeComponent();
        }
    }
}
