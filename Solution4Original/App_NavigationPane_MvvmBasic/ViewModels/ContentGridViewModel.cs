﻿using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

using App_NavigationPane_MvvmBasic.Core.Models;
using App_NavigationPane_MvvmBasic.Core.Services;
using App_NavigationPane_MvvmBasic.Helpers;
using App_NavigationPane_MvvmBasic.Services;
using App_NavigationPane_MvvmBasic.Views;

using Microsoft.Toolkit.Uwp.UI.Animations;

namespace App_NavigationPane_MvvmBasic.ViewModels
{
    public class ContentGridViewModel : Observable
    {
        private ICommand _itemClickCommand;

        public ICommand ItemClickCommand => _itemClickCommand ?? (_itemClickCommand = new RelayCommand<SampleOrder>(OnItemClick));

        public ObservableCollection<SampleOrder> Source
        {
            get
            {
                // TODO WTS: Replace this with your actual data
                return SampleDataService.GetContentGridData();
            }
        }

        public ContentGridViewModel()
        {
        }

        private void OnItemClick(SampleOrder clickedItem)
        {
            if (clickedItem != null)
            {
                NavigationService.Frame.SetListDataItemForNextConnectedAnnimation(clickedItem);
                NavigationService.Navigate<ContentGridDetailPage>(clickedItem.OrderId);
            }
        }
    }
}
