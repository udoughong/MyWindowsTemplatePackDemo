﻿using System;
using System.Collections.ObjectModel;

using App_NavigationPane_MvvmBasic.Core.Models;
using App_NavigationPane_MvvmBasic.Core.Services;
using App_NavigationPane_MvvmBasic.Helpers;

namespace App_NavigationPane_MvvmBasic.ViewModels
{
    public class ChartViewModel : Observable
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