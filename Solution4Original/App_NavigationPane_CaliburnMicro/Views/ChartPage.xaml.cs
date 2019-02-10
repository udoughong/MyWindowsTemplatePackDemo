﻿using System;

using App_NavigationPane_CaliburnMicro.ViewModels;

using Windows.UI.Xaml.Controls;

namespace App_NavigationPane_CaliburnMicro.Views
{
    public sealed partial class ChartPage : Page
    {
        // TODO WTS: Change the chart as appropriate to your app.
        // For help see http://docs.telerik.com/windows-universal/controls/radchart/getting-started
        public ChartPage()
        {
            InitializeComponent();
        }

        private ChartViewModel ViewModel
        {
            get { return DataContext as ChartViewModel; }
        }
    }
}
