﻿using App_NavigationPane_CaliburnMicro_Blank.ViewModels;

using Caliburn.Micro;

using Windows.UI.Xaml.Controls;

using WinUI = Microsoft.UI.Xaml.Controls;

namespace App_NavigationPane_CaliburnMicro_Blank.Views
{
    // TODO WTS: Change the icons and titles for all NavigationViewItems in ShellPage.xaml.
    public sealed partial class ShellPage : IShellView
    {
        private ShellViewModel ViewModel => DataContext as ShellViewModel;

        public ShellPage()
        {
            InitializeComponent();
        }

        public INavigationService CreateNavigationService(WinRTContainer container)
        {
            var navigationService = container.RegisterNavigationService(shellFrame);
            navigationViewHeaderBehavior.Initialize(navigationService);
            return navigationService;
        }

        public WinUI.NavigationView GetNavigationView()
        {
            return navigationView;
        }

        public Frame GetFrame()
        {
            return shellFrame;
        }
    }
}