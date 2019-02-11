using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

using App_HorizontalNavigationPane_CaliburnMicro.Core.Models;
using App_HorizontalNavigationPane_CaliburnMicro.Core.Services;
using App_HorizontalNavigationPane_CaliburnMicro.Helpers;
using App_HorizontalNavigationPane_CaliburnMicro.Services;

using Caliburn.Micro;

namespace App_HorizontalNavigationPane_CaliburnMicro.ViewModels
{
    public class ImageGalleryViewModel : Screen
    {
        public const string ImageGallerySelectedIdKey = "ImageGallerySelectedIdKey";

        private readonly INavigationService _navigationService;
        private readonly IConnectedAnimationService _connectedAnimationService;

        public BindableCollection<SampleImage> Source { get; } = new BindableCollection<SampleImage>();

        public ImageGalleryViewModel(INavigationService navigationService, IConnectedAnimationService connectedAnimationService)
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

        public void OnImageSelected(SampleImage image)
        {
            ImagesNavigationHelper.AddImageId(ImageGallerySelectedIdKey, image.ID);
            _connectedAnimationService.SetListDataItemForNextConnectedAnnimation(image);
            _navigationService.For<ImageGalleryDetailViewModel>()
                .WithParam(v => v.ID, image.ID)
                .Navigate();
        }
    }
}
