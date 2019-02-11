﻿using System;
using System.Threading.Tasks;

using App_NavigationPane_Prism.Helpers;

using Prism.Mvvm;

using Windows.ApplicationModel.DataTransfer.ShareTarget;

namespace App_NavigationPane_Prism.ViewModels
{
    public class SharedDataViewModelBase : BindableBase
    {
        private string _dataFormat;

        public string DataFormat
        {
            get => _dataFormat;
            set => SetProperty(ref _dataFormat, value);
        }

        private string _pageTitle;

        public string PageTitle
        {
            get => _pageTitle;
            set => SetProperty(ref _pageTitle, value);
        }

        private string _title;

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
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
