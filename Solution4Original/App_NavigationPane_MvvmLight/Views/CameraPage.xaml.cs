using App_NavigationPane_MvvmLight.ViewModels;

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace App_NavigationPane_MvvmLight.Views
{
    public sealed partial class CameraPage : Page
    {
        private CameraViewModel ViewModel
        {
            get { return ViewModelLocator.Current.CameraViewModel; }
        }

        public CameraPage()
        {
            InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            await cameraControl.InitializeCameraAsync();
        }

        protected override async void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
            await cameraControl.CleanupCameraAsync();
        }
    }
}
