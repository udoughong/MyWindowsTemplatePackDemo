﻿using System;
using System.Threading.Tasks;

using App_HorizontalNavigationPane_MvvmLight.Helpers;

using Windows.ApplicationModel.DataTransfer;
using Windows.ApplicationModel.DataTransfer.ShareTarget;

namespace App_HorizontalNavigationPane_MvvmLight.ViewModels
{
    public class SharedDataWebLinkViewModel : SharedDataViewModelBase
    {
        private Uri _uri;

        public Uri Uri
        {
            get => _uri;
            set => Set(ref _uri, value);
        }

        public SharedDataWebLinkViewModel()
        {
        }

        public override async Task LoadDataAsync(ShareOperation shareOperation)
        {
            await base.LoadDataAsync(shareOperation);

            PageTitle = "ShareTarget_WebLinkTitle".GetLocalized();
            DataFormat = StandardDataFormats.WebLink;
            Uri = await shareOperation.GetWebLinkAsync();
        }
    }
}
