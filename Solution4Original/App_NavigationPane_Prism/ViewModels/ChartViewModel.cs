using System;
using System.Collections.ObjectModel;

using App_NavigationPane_Prism.Core.Models;
using App_NavigationPane_Prism.Core.Services;

using Prism.Windows.Mvvm;

namespace App_NavigationPane_Prism.ViewModels
{
    public class ChartViewModel : ViewModelBase
    {
        private readonly ISampleDataService _sampleDataService;

        public ChartViewModel(ISampleDataService sampleDataServiceInstance)
        {
            _sampleDataService = sampleDataServiceInstance;
        }

        public ObservableCollection<DataPoint> Source
        {
            get
            {
                // TODO WTS: Replace this with your actual data
                return _sampleDataService.GetChartSampleData();
            }
        }
    }
}
