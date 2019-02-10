using System;

using App_Blank_MvvmLight.ViewModels;

using Windows.ApplicationModel.DataTransfer.ShareTarget;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace App_Blank_MvvmLight.Views
{
    // TODO WTS: Remove this example page when/if it's not needed.
    // This page is an example of how to handle data that is shared with your app.
    // You can either change this page to meet your needs, or use another and delete this page.
    public sealed partial class ShareTargetPage : Page
    {
        private ShareTargetViewModel ViewModel
        {
            get { return ViewModelLocator.Current.ShareTargetViewModel; }
        }

        public ShareTargetPage()
        {
            InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            await ViewModel.LoadAsync(e.Parameter as ShareOperation);
        }
    }
}
