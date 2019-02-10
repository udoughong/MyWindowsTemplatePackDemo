using App_NavigationPane_CaliburnMicro.ViewModels;

namespace App_NavigationPane_CaliburnMicro.Views
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
