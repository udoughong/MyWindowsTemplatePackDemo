using System;

using App_NavigationPane_CaliburnMicro.Core.Models;

using Caliburn.Micro;

namespace App_NavigationPane_CaliburnMicro.ViewModels
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
