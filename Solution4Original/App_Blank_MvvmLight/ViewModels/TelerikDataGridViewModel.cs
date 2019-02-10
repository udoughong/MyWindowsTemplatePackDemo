﻿using System;
using System.Collections.ObjectModel;

using App_Blank_MvvmLight.Core.Models;
using App_Blank_MvvmLight.Core.Services;

using GalaSoft.MvvmLight;

namespace App_Blank_MvvmLight.ViewModels
{
    public class TelerikDataGridViewModel : ViewModelBase
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
