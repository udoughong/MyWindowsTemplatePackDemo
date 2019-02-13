using App_Blank_Prism.ViewModels;

using Windows.UI.Xaml.Controls;

namespace App_Blank_Prism.Views
{
    public sealed partial class CameraPage : Page
    {
        private CameraViewModel ViewModel => DataContext as CameraViewModel;

        public CameraPage()
        {
            InitializeComponent();
            ViewModel.Initialize(cameraControl);
        }
    }
}
