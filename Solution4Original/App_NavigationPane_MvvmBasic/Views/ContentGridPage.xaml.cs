using System;

using App_NavigationPane_MvvmBasic.ViewModels;

using Windows.UI.Xaml.Controls;

namespace App_NavigationPane_MvvmBasic.Views
{
    public sealed partial class ContentGridPage : Page
    {
        public ContentGridViewModel ViewModel { get; } = new ContentGridViewModel();

        public ContentGridPage()
        {
            InitializeComponent();
        }
    }
}
