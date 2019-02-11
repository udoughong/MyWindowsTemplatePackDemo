using System;
using System.Linq;

using App_HorizontalNavigationPane_CaliburnMicro.Core.Models;
using App_HorizontalNavigationPane_CaliburnMicro.Core.Services;
using App_HorizontalNavigationPane_CaliburnMicro.Services;

using Caliburn.Micro;

namespace App_HorizontalNavigationPane_CaliburnMicro.ViewModels
{
    public class ContentGridDetailViewModel : Screen
    {
        private readonly IConnectedAnimationService _connectedAnimationService;

        private SampleOrder _item;

        public SampleOrder Item
        {
            get { return _item; }
            set { Set(ref _item, value); }
        }

        public ContentGridDetailViewModel(IConnectedAnimationService connectedAnimationService)
        {
            _connectedAnimationService = connectedAnimationService;
        }

        public void Initialize(long orderId)
        {
            // TODO WTS: Replace this with your actual data
            var data = SampleDataService.GetContentGridData();
            Item = data.First(i => i.OrderId == orderId);
        }

        public void SetListDataItemForNextConnectedAnnimation()
        {
            _connectedAnimationService.SetListDataItemForNextConnectedAnnimation(Item);
        }
    }
}
