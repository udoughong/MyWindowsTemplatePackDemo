using System;
using System.Linq;

using App_HorizontalNavigationPane_CaliburnMicro.Core.Models;
using App_HorizontalNavigationPane_CaliburnMicro.Core.Services;
using App_HorizontalNavigationPane_CaliburnMicro.Helpers;
using App_HorizontalNavigationPane_CaliburnMicro.Services;

using Caliburn.Micro;

using Windows.System;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;

namespace App_HorizontalNavigationPane_CaliburnMicro.ViewModels
{
    public class ImageGalleryDetailViewModel : Screen
    {
        private readonly INavigationService _navigationService;
        private readonly IConnectedAnimationService _connectedAnimationService;
        private SampleImage _selectedImage;

        public SampleImage SelectedImage
        {
            get => _selectedImage;
            set
            {
                Set(ref _selectedImage, value);
                ImagesNavigationHelper.UpdateImageId(ImageGalleryViewModel.ImageGallerySelectedIdKey, SelectedImage.ID);
            }
        }

        public string ID { get; set; }

        public BindableCollection<SampleImage> Source { get; } = new BindableCollection<SampleImage>();

        public ImageGalleryDetailViewModel(INavigationService navigationService, IConnectedAnimationService connectedAnimationService)
        {
            _navigationService = navigationService;
            _connectedAnimationService = connectedAnimationService;
        }

        protected override void OnInitialize()
        {
            base.OnInitialize();

            // TODO WTS: Replace this with your actual data
            Source.AddRange(SampleDataService.GetGallerySampleData());
        }

        public void Initialize(NavigationMode navigationMode)
        {
            if (!string.IsNullOrEmpty(ID) && navigationMode == NavigationMode.New)
            {
                SelectedImage = Source.First(i => i.ID == ID);
            }
            else
            {
                var selectedImageId = ImagesNavigationHelper.GetImageId(ImageGalleryViewModel.ImageGallerySelectedIdKey);
                if (!string.IsNullOrEmpty(selectedImageId))
                {
                    SelectedImage = Source.FirstOrDefault(i => i.ID == selectedImageId);
                }
            }
        }

        public void OnPageKeyDown(KeyRoutedEventArgs e)
        {
            if (e.Key == VirtualKey.Escape && _navigationService.CanGoBack)
            {
                _navigationService.GoBack();
                e.Handled = true;
            }
        }

        public void UpdateConnectedAnimation()
        {
            _connectedAnimationService.SetListDataItemForNextConnectedAnnimation(SelectedImage);
            ImagesNavigationHelper.RemoveImageId(ImageGalleryViewModel.ImageGallerySelectedIdKey);
        }
    }
}
