﻿using System.Collections.ObjectModel;

using App_Blank_Prism.Core.Models;
using App_Blank_Prism.Core.Services;

using Prism.Windows.Mvvm;

namespace App_Blank_Prism.ViewModels
{
    public class TelerikDataGridViewModel : ViewModelBase
    {
        private readonly ISampleDataService _sampleDataService;

        public TelerikDataGridViewModel(ISampleDataService sampleDataServiceInstance)
        {
            _sampleDataService = sampleDataServiceInstance;
        }

        public ObservableCollection<SampleOrder> Source => _sampleDataService.GetGridSampleData();
    }
}