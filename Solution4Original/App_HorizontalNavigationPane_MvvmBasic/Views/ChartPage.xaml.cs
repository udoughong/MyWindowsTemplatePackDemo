using System;

using App_HorizontalNavigationPane_MvvmBasic.ViewModels;

using Windows.UI.Xaml.Controls;

namespace App_HorizontalNavigationPane_MvvmBasic.Views
{
    public sealed partial class ChartPage : Page
    {
        public ChartViewModel ViewModel { get; } = new ChartViewModel();

        // TODO WTS: Change the chart as appropriate to your app.
        // For help see http://docs.telerik.com/windows-universal/controls/radchart/getting-started
        public ChartPage()
        {
            InitializeComponent();
        }
    }
}
