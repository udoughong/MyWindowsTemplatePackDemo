﻿using System;
using System.Collections.ObjectModel;

using App_Blank_CaliburnMicro.Core.Models;
using App_Blank_CaliburnMicro.Core.Services;
using App_Blank_CaliburnMicro.Helpers;

using Caliburn.Micro;

namespace App_Blank_CaliburnMicro.ViewModels
{
    public class DataGridViewModel : Screen
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
