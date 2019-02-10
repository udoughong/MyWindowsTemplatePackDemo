using System;

using App_Blank_CaliburnMicro.Core.Models;

using Caliburn.Micro;

namespace App_Blank_CaliburnMicro.ViewModels
{
    public class MasterDetailDetailViewModel : Screen
    {
        public MasterDetailDetailViewModel(SampleOrder item)
        {
            Item = item;
        }

        public SampleOrder Item { get; }
    }
}
