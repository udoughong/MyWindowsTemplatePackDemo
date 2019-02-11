using App_HorizontalNavigationPane_CaliburnMicro.ViewModels;

namespace App_HorizontalNavigationPane_CaliburnMicro.Views
{
    public sealed partial class SharedDataStorageItemsView
    {
        public SharedDataStorageItemsView()
        {
            InitializeComponent();
        }

        public SharedDataStorageItemsViewModel ViewModel => DataContext as SharedDataStorageItemsViewModel;
    }
}
