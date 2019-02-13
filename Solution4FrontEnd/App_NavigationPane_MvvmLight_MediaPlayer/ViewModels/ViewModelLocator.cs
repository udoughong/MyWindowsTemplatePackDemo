﻿using System;

using App_NavigationPane_MvvmLight_MediaPlayer.Services;
using App_NavigationPane_MvvmLight_MediaPlayer.Views;

using GalaSoft.MvvmLight.Ioc;

namespace App_NavigationPane_MvvmLight_MediaPlayer.ViewModels
{
    [Windows.UI.Xaml.Data.Bindable]
    public class ViewModelLocator
    {
        private static ViewModelLocator _current;

        public static ViewModelLocator Current => _current ?? (_current = new ViewModelLocator());

        private ViewModelLocator()
        {
            SimpleIoc.Default.Register(() => new NavigationServiceEx());
            SimpleIoc.Default.Register<ShellViewModel>();
            Register<MainViewModel, MainPage>();
            Register<MediaPlayerViewModel, MediaPlayerPage>();
        }

        // A Guid is generated as a unique key for each instance as reusing the same VM instance in multiple MediaPlayerElement instances can cause playback errors
        public MediaPlayerViewModel MediaPlayerViewModel => SimpleIoc.Default.GetInstance<MediaPlayerViewModel>(Guid.NewGuid().ToString());

        public MainViewModel MainViewModel => SimpleIoc.Default.GetInstance<MainViewModel>();

        public ShellViewModel ShellViewModel => SimpleIoc.Default.GetInstance<ShellViewModel>();

        public NavigationServiceEx NavigationService => SimpleIoc.Default.GetInstance<NavigationServiceEx>();

        public void Register<VM, V>()
            where VM : class
        {
            SimpleIoc.Default.Register<VM>();

            NavigationService.Configure(typeof(VM).FullName, typeof(V));
        }
    }
}
