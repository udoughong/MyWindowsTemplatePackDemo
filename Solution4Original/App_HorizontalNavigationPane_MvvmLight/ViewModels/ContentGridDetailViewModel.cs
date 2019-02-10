using System;
using System.Linq;

using App_HorizontalNavigationPane_MvvmLight.Core.Models;
using App_HorizontalNavigationPane_MvvmLight.Core.Services;

using GalaSoft.MvvmLight;

namespace App_HorizontalNavigationPane_MvvmLight.ViewModels
{
    public class ContentGridDetailViewModel : ViewModelBase
    {
        private SampleOrder _item;

        public SampleOrder Item
        {
            get { return _item; }
            set { Set(ref _item, value); }
        }

        public ContentGridDetailViewModel()
        {
        }

        public void Initialize(long orderId)
        {
            var data = SampleDataService.GetContentGridData();
            Item = data.First(i => i.OrderId == orderId);
        }
    }
}
