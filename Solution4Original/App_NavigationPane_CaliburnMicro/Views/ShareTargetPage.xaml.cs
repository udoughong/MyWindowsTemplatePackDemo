﻿using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using App_NavigationPane_CaliburnMicro.ViewModels;

using Windows.ApplicationModel.DataTransfer.ShareTarget;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace App_NavigationPane_CaliburnMicro.Views
{
    public sealed partial class ShareTargetPage : Page
    {
        public ShareTargetViewModel ViewModel { get; } = new ShareTargetViewModel();

        public ShareTargetPage()
        {
            DataContext = ViewModel;
            InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            await ViewModel.LoadAsync(e.Parameter as ShareOperation);
        }
    }
}
