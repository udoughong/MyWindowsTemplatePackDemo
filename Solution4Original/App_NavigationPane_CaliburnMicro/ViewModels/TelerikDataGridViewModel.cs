using System;
using System.Collections.ObjectModel;

using App_NavigationPane_CaliburnMicro.Core.Models;
using App_NavigationPane_CaliburnMicro.Core.Services;
using App_NavigationPane_CaliburnMicro.Helpers;

using Caliburn.Micro;

namespace App_NavigationPane_CaliburnMicro.ViewModels
{
    public class TelerikDataGridViewModel : Screen
    {
        public ObservableCollection<SampleOrder> Source
        {
            get
            {
                // TODO WTS: Replace this with your actual data
                return SampleDataService.GetGridSampleData();
            }
        }
    }
}
