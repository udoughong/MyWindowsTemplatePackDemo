﻿using System;

using App_NavigationPane_MvvmLight.ViewModels;

using Windows.UI.Xaml.Controls;

namespace App_NavigationPane_MvvmLight.Views
{
    public sealed partial class MainPage : Page
    {
        private MainViewModel ViewModel
        {
            get { return ViewModelLocator.Current.MainViewModel; }
        }

        public MainPage()
        {
            InitializeComponent();
        }
    }
}
