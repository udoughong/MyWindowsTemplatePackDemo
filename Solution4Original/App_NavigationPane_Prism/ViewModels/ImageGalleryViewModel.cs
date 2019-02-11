using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

using App_NavigationPane_Prism.Core.Models;
using App_NavigationPane_Prism.Core.Services;
using App_NavigationPane_Prism.Helpers;
using App_NavigationPane_Prism.Services;

using Prism.Commands;
using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;

using Windows.UI.Xaml.Controls;

namespace App_NavigationPane_Prism.ViewModels
{
    public class ImageGalleryViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly ISampleDataService _sampleDataService;
        private readonly IConnectedAnimationService _connectedAnimationService;

        public const string ImageGallerySelectedIdKey = "ImageGallerySelectedIdKey";

        private ObservableCollection<SampleImage> _source;
        private ICommand _itemSelectedCommand;

        public ObservableCollection<SampleImage> Source
        {
            get => _source;
            set => SetProperty(ref _source, value);
        }

        public ICommand ItemSelectedCommand => _itemSelectedCommand ?? (_itemSelectedCommand = new DelegateCommand<ItemClickEventArgs>(OnsItemSelected));

        public ImageGalleryViewModel(INavigationService navigationServiceInstance, ISampleDataService sampleDataServiceInstance, IConnectedAnimationService connectedAnimationService)
        {
            _navigationService = navigationServiceInstance;

            // TODO WTS: Replace this with your actual data
            _sampleDataService = sampleDataServiceInstance;
            _connectedAnimationService = connectedAnimationService;
            Source = _sampleDataService.GetGallerySampleData();
        }

        private void OnsItemSelected(ItemClickEventArgs args)
        {
            var selected = args.ClickedItem as SampleImage;
            ImagesNavigationHelper.AddImageId(ImageGallerySelectedIdKey, selected.ID);
            _connectedAnimationService.SetListDataItemForNextConnectedAnnimation(selected);
            _navigationService.Navigate(PageTokens.ImageGalleryDetailPage, selected.ID);
        }
    }
}
