using App_NavigationPane_CaliburnMicro.ViewModels;

namespace App_NavigationPane_CaliburnMicro.Views
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
