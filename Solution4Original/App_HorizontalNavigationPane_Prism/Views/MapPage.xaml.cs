﻿using System;

using App_HorizontalNavigationPane_Prism.ViewModels;

using Windows.UI.Xaml.Controls;

namespace App_HorizontalNavigationPane_Prism.Views
{
    public sealed partial class MapPage : Page
    {
        private MapViewModel ViewModel => DataContext as MapViewModel;

        public MapPage()
        {
            InitializeComponent();
        }
    }
}
