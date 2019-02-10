using System;
using System.Linq;
using System.Threading.Tasks;

using App_NavigationPane_CaliburnMicro.Core.Services;
using App_NavigationPane_CaliburnMicro.Helpers;

using Caliburn.Micro;

namespace App_NavigationPane_CaliburnMicro.ViewModels
{
    public class MasterDetailViewModel : Conductor<MasterDetailDetailViewModel>.Collection.OneActive
    {
        protected override async void OnInitialize()
        {
            base.OnInitialize();

            await LoadDataAsync();
        }

        public async Task LoadDataAsync()
        {
            Items.Clear();

            var data = await SampleDataService.GetSampleModelDataAsync();

            Items.AddRange(data.Select(d => new MasterDetailDetailViewModel(d)));
        }
    }
}
