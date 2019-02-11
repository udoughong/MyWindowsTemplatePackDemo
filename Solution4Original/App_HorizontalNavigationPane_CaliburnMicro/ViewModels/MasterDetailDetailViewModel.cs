using System;

using App_HorizontalNavigationPane_CaliburnMicro.Core.Models;

using Caliburn.Micro;

namespace App_HorizontalNavigationPane_CaliburnMicro.ViewModels
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
