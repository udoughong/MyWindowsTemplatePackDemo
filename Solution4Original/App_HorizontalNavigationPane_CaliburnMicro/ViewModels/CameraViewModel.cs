using System;

using App_HorizontalNavigationPane_CaliburnMicro.EventHandlers;
using App_HorizontalNavigationPane_CaliburnMicro.Helpers;

using Caliburn.Micro;

using Windows.UI.Xaml.Media.Imaging;

namespace App_HorizontalNavigationPane_CaliburnMicro.ViewModels
{
    public class CameraViewModel : Screen
    {
        private BitmapImage _photo;

        public BitmapImage Photo
        {
            get { return _photo; }
            set { Set(ref _photo, value); }
        }

        public void OnPhotoTaken(CameraControlEventArgs args)
        {
            if (!string.IsNullOrEmpty(args.Photo))
            {
                Photo = new BitmapImage(new Uri(args.Photo));
            }
        }
    }
}
