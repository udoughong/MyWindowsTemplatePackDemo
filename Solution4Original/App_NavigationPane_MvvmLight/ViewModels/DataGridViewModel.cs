﻿using System;
using System.Collections.ObjectModel;

using App_NavigationPane_MvvmLight.Core.Models;
using App_NavigationPane_MvvmLight.Core.Services;

using GalaSoft.MvvmLight;

namespace App_NavigationPane_MvvmLight.ViewModels
{
    public class DataGridViewModel : ViewModelBase
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
