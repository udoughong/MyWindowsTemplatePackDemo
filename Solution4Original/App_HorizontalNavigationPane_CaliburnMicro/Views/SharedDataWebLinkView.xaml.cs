using App_HorizontalNavigationPane_CaliburnMicro.ViewModels;

namespace App_HorizontalNavigationPane_CaliburnMicro.Views
{
    public sealed partial class SharedDataWebLinkView
    {
        public SharedDataWebLinkView()
        {
            InitializeComponent();
        }

        public SharedDataWebLinkViewModel ViewModel => DataContext as SharedDataWebLinkViewModel;
    }
}
