using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

using App_Blank_Prism.Core.Models;
using App_Blank_Prism.Core.Services;
using App_Blank_Prism.Services;

using Prism.Commands;
using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;

using Windows.UI.Xaml.Navigation;

namespace App_Blank_Prism.ViewModels
{
    public class ContentGridDetailViewModel : ViewModelBase
    {
        private readonly ISampleDataService _sampleDataService;
        private readonly IConnectedAnimationService _connectedAnimationService;
        private readonly INavigationService _navigationService;
        private ICommand _goBackCommand;

        private SampleOrder _item;

        public SampleOrder Item
        {
            get { return _item; }
            set { SetProperty(ref _item, value); }
        }

        public ICommand GoBackCommand => _goBackCommand ?? (_goBackCommand = new DelegateCommand(OnGoBack));

        public ContentGridDetailViewModel(ISampleDataService sampleDataServiceInstance, IConnectedAnimationService connectedAnimationService, INavigationService navigationService)
        {
            // TODO WTS: Replace this with your actual data
            _sampleDataService = sampleDataServiceInstance;
            _connectedAnimationService = connectedAnimationService;
            _navigationService = navigationService;
        }

        private void OnGoBack()
        {
            if (_navigationService.CanGoBack())
            {
                _navigationService.GoBack();
            }
        }

        public override void OnNavigatedTo(NavigatedToEventArgs e, Dictionary<string, object> viewModelState)
        {
            base.OnNavigatedTo(e, viewModelState);
            if (e.Parameter is long orderId)
            {
                Item = _sampleDataService.GetContentGridData().First(i => i.OrderId == orderId);
            }
        }

        public override void OnNavigatingFrom(NavigatingFromEventArgs e, Dictionary<string, object> viewModelState, bool suspending)
        {
            base.OnNavigatingFrom(e, viewModelState, suspending);
            if (e.NavigationMode == NavigationMode.Back)
            {
                _connectedAnimationService.SetListDataItemForNextConnectedAnnimation(Item);
            }
        }
    }
}
