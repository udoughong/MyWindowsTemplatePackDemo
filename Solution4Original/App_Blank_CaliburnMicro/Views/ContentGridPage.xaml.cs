using System;

using App_Blank_CaliburnMicro.ViewModels;

using Windows.UI.Xaml.Controls;

namespace App_Blank_CaliburnMicro.Views
{
    public sealed partial class ContentGridPage : Page
    {
        public ContentGridPage()
        {
            InitializeComponent();
        }

        private ContentGridViewModel ViewModel
        {
            get { return DataContext as ContentGridViewModel; }
        }
    }
}
