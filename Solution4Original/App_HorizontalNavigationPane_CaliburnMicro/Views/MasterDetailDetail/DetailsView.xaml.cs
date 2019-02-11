using System;

using App_HorizontalNavigationPane_CaliburnMicro.ViewModels;

namespace App_HorizontalNavigationPane_CaliburnMicro.Views.MasterDetailDetail
{
    public sealed partial class DetailsView
    {
        public DetailsView()
        {
            InitializeComponent();
        }

        public MasterDetailDetailViewModel ViewModel => DataContext as MasterDetailDetailViewModel;
    }
}
