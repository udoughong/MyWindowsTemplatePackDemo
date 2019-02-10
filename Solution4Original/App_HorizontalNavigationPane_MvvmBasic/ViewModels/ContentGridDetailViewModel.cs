using System;
using System.Linq;

using App_HorizontalNavigationPane_MvvmBasic.Core.Models;
using App_HorizontalNavigationPane_MvvmBasic.Core.Services;
using App_HorizontalNavigationPane_MvvmBasic.Helpers;

namespace App_HorizontalNavigationPane_MvvmBasic.ViewModels
{
    public class ContentGridDetailViewModel : Observable
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
