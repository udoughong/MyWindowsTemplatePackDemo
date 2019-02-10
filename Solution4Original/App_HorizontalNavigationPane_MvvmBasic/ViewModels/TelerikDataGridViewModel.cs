using System;
using System.Collections.ObjectModel;

using App_HorizontalNavigationPane_MvvmBasic.Core.Models;
using App_HorizontalNavigationPane_MvvmBasic.Core.Services;
using App_HorizontalNavigationPane_MvvmBasic.Helpers;

namespace App_HorizontalNavigationPane_MvvmBasic.ViewModels
{
    public class TelerikDataGridViewModel : Observable
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
