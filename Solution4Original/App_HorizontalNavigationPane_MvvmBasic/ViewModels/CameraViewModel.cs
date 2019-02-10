﻿using System;
using System.Windows.Input;

using App_HorizontalNavigationPane_MvvmBasic.EventHandlers;
using App_HorizontalNavigationPane_MvvmBasic.Helpers;

using Windows.UI.Xaml.Media.Imaging;

namespace App_HorizontalNavigationPane_MvvmBasic.ViewModels
{
    public class CameraViewModel : Observable
    {
        private ICommand _photoTakenCommand;
        private BitmapImage _photo;

        public BitmapImage Photo
        {
            get { return _photo; }
            set { Set(ref _photo, value); }
        }

        public ICommand PhotoTakenCommand => _photoTakenCommand ?? (_photoTakenCommand = new RelayCommand<CameraControlEventArgs>(OnPhotoTaken));

        private void OnPhotoTaken(CameraControlEventArgs args)
        {
            if (!string.IsNullOrEmpty(args.Photo))
            {
                Photo = new BitmapImage(new Uri(args.Photo));
            }
        }
    }
}