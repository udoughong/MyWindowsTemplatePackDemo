using System;

using App_NavigationPane_CaliburnMicro.ViewModels;

namespace App_NavigationPane_CaliburnMicro.Views.MasterDetailDetail
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
