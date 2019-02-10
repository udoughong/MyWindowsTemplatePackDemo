using System;
using System.Linq;

using App_NavigationPane_MvvmBasic.Core.Models;
using App_NavigationPane_MvvmBasic.Core.Services;
using App_NavigationPane_MvvmBasic.Helpers;

namespace App_NavigationPane_MvvmBasic.ViewModels
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
