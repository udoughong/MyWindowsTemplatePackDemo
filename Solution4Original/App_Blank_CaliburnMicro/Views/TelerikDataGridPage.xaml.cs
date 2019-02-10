using System;

using App_Blank_CaliburnMicro.ViewModels;

using Windows.UI.Xaml.Controls;

namespace App_Blank_CaliburnMicro.Views
{
    public sealed partial class TelerikDataGridPage : Page
    {
        // TODO WTS: Change the grid as appropriate to your app, adjust the column definitions on TelerikDataGridPage.xaml.
        // For help see http://docs.telerik.com/windows-universal/controls/raddatagrid/gettingstarted
        // You may also want to extend the grid to work with the RadDataForm http://docs.telerik.com/windows-universal/controls/raddataform/dataform-gettingstarted
        public TelerikDataGridPage()
        {
            InitializeComponent();
        }

        private TelerikDataGridViewModel ViewModel
        {
            get { return DataContext as TelerikDataGridViewModel; }
        }
    }
}
