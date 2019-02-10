﻿using System;
using System.Threading.Tasks;

using GalaSoft.MvvmLight;

using Windows.ApplicationModel.DataTransfer.ShareTarget;

namespace App_NavigationPane_MvvmLight.ViewModels
{
    public class SharedDataViewModelBase : ViewModelBase
    {
        private string _dataFormat;

        public string DataFormat
        {
            get => _dataFormat;
            set => Set(ref _dataFormat, value);
        }

        private string _pageTitle;

        public string PageTitle
        {
            get => _pageTitle;
            set => Set(ref _pageTitle, value);
        }

        private string _title;

        public string Title
        {
            get => _title;
            set => Set(ref _title, value);
        }

        public SharedDataViewModelBase()
        {
        }

        public virtual async Task LoadDataAsync(ShareOperation shareOperation)
        {
            Title = shareOperation.Data.Properties.Title;
            await Task.CompletedTask;
        }
    }
}
