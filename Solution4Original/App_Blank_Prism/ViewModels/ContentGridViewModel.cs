﻿using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

using App_Blank_Prism.Core.Models;
using App_Blank_Prism.Core.Services;
using App_Blank_Prism.Services;

using Prism.Commands;
using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;

namespace App_Blank_Prism.ViewModels
{
    public class ContentGridViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly ISampleDataService _sampleDataService;
        private readonly IConnectedAnimationService _connectedAnimationService;

        private ObservableCollection<SampleOrder> _source;
        private ICommand _itemClickCommand;

        public ObservableCollection<SampleOrder> Source
        {
            get => _source;
            set => SetProperty(ref _source, value);
        }

        public ICommand ItemClickCommand => _itemClickCommand ?? (_itemClickCommand = new DelegateCommand<SampleOrder>(OnItemClick));

        public ContentGridViewModel(INavigationService navigationServiceInstance, ISampleDataService sampleDataServiceInstance, IConnectedAnimationService connectedAnimationService)
        {
            _navigationService = navigationServiceInstance;
            _sampleDataService = sampleDataServiceInstance;
            _connectedAnimationService = connectedAnimationService;

            // TODO WTS: Replace this with your actual data
            Source = _sampleDataService.GetContentGridData();
        }

        private void OnItemClick(SampleOrder clickedItem)
        {
            if (clickedItem != null)
            {
                _connectedAnimationService.SetListDataItemForNextConnectedAnnimation(clickedItem);
                _navigationService.Navigate(PageTokens.ContentGridDetailPage, clickedItem.OrderId);
            }
        }
    }
}
