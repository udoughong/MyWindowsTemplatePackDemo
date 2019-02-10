using System;
using System.Collections.ObjectModel;

using App_Blank_CaliburnMicro.Core.Models;
using App_Blank_CaliburnMicro.Core.Services;
using App_Blank_CaliburnMicro.Helpers;
using App_Blank_CaliburnMicro.Services;
using App_Blank_CaliburnMicro.Views;

using Caliburn.Micro;

namespace App_Blank_CaliburnMicro.ViewModels
{
    public class ContentGridViewModel : Screen
    {
        private readonly INavigationService _navigationService;
        private readonly IConnectedAnimationService _connectedAnimationService;

        public ObservableCollection<SampleOrder> Source
        {
            get
            {
                // TODO WTS: Replace this with your actual data
                return SampleDataService.GetContentGridData();
            }
        }

        public ContentGridViewModel(INavigationService navigationService, IConnectedAnimationService connectedAnimationService)
        {
            _navigationService = navigationService;
            _connectedAnimationService = connectedAnimationService;
        }

        public void OnItemSelected(SampleOrder clickedItem)
        {
            if (clickedItem != null)
            {
                _connectedAnimationService.SetListDataItemForNextConnectedAnnimation(clickedItem);
                _navigationService.Navigate(typeof(ContentGridDetailPage), clickedItem.OrderId);
            }
        }
    }
}
