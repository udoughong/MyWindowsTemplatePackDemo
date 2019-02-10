using System;

using App_Blank_MvvmBasic.ViewModels;

using Windows.UI.Xaml.Controls;

namespace App_Blank_MvvmBasic.Views
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
