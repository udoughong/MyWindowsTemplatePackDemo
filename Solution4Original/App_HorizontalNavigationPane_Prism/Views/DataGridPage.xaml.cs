using System;

using App_HorizontalNavigationPane_Prism.ViewModels;

using Windows.UI.Xaml.Controls;

namespace App_HorizontalNavigationPane_Prism.Views
{
    public sealed partial class DataGridPage : Page
    {
        private DataGridViewModel ViewModel => DataContext as DataGridViewModel;

        // TODO WTS: Change the grid as appropriate to your app, adjust the column definitions on DataGridPage.xaml.
        // For more details see the documentation at https://docs.microsoft.com/windows/communitytoolkit/controls/datagrid
        public DataGridPage()
        {
            InitializeComponent();
        }
    }
}
