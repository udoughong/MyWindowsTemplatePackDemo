using System;
using System.Collections.ObjectModel;

using App_NavigationPane_MvvmLight.Core.Models;
using App_NavigationPane_MvvmLight.Core.Services;

using GalaSoft.MvvmLight;

namespace App_NavigationPane_MvvmLight.ViewModels
{
    public class ChartViewModel : ViewModelBase
    {
        public ChartViewModel()
        {
        }

        public ObservableCollection<DataPoint> Source
        {
            get
            {
                // TODO WTS: Replace this with your actual data
                return SampleDataService.GetChartSampleData();
            }
        }
    }
}
