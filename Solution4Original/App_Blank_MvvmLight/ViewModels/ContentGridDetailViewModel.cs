using System;
using System.Linq;
using System.Windows.Input;

using App_Blank_MvvmLight.Core.Models;
using App_Blank_MvvmLight.Core.Services;
using App_Blank_MvvmLight.Helpers;
using App_Blank_MvvmLight.Services;

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace App_Blank_MvvmLight.ViewModels
{
    public class ContentGridDetailViewModel : ViewModelBase
    {
        private SampleOrder _item;

        public SampleOrder Item
        {
            get { return _item; }
            set { Set(ref _item, value); }
        }

        public static NavigationServiceEx NavigationService => ViewModelLocator.Current.NavigationService;

        private ICommand _goBackCommand;

        public ICommand GoBackCommand => _goBackCommand ?? (_goBackCommand = new RelayCommand(OnGoBack));

        public ContentGridDetailViewModel()
        {
        }

        public void Initialize(long orderId)
        {
            var data = SampleDataService.GetContentGridData();
            Item = data.First(i => i.OrderId == orderId);
        }

        private void OnGoBack()
        {
            if (NavigationService.CanGoBack)
            {
                NavigationService.GoBack();
            }
        }
    }
}
