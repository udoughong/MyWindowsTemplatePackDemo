﻿using System;

using App_NavigationPane_Prism_Blank.ViewModels;

using Windows.UI.Xaml.Controls;

namespace App_NavigationPane_Prism_Blank.Views
{
    public sealed partial class MainPage : Page
    {
        private MainViewModel ViewModel => DataContext as MainViewModel;

        public MainPage()
        {
            InitializeComponent();
        }
    }
}