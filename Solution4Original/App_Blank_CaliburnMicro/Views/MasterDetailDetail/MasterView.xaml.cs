using System;

using App_Blank_CaliburnMicro.ViewModels;

namespace App_Blank_CaliburnMicro.Views.MasterDetailDetail
{
    public sealed partial class MasterView
    {
        public MasterView()
        {
            InitializeComponent();
        }

        public MasterDetailDetailViewModel ViewModel => DataContext as MasterDetailDetailViewModel;
    }
}
