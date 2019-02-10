using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

using App_NavigationPane_MvvmLight.Core.Models;
using App_NavigationPane_MvvmLight.Core.Services;
using App_NavigationPane_MvvmLight.Helpers;
using App_NavigationPane_MvvmLight.Services;

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

using Microsoft.Toolkit.Uwp.UI.Animations;

using Windows.UI.Xaml.Controls;

namespace App_NavigationPane_MvvmLight.ViewModels
{
    public class ImageGalleryViewModel : ViewModelBase
    {
        public NavigationServiceEx NavigationService => ViewModelLocator.Current.NavigationService;

        public const string ImageGallerySelectedIdKey = "ImageGallerySelectedIdKey";

        private ObservableCollection<SampleImage> _source;
        private ICommand _itemSelectedCommand;

        public ObservableCollection<SampleImage> Source
        {
            get => _source;
            set => Set(ref _source, value);
        }

        public ICommand ItemSelectedCommand => _itemSelectedCommand ?? (_itemSelectedCommand = new RelayCommand<ItemClickEventArgs>(OnsItemSelected));

        public ImageGalleryViewModel()
        {
            // TODO WTS: Replace this with your actual data
            Source = SampleDataService.GetGallerySampleData();
        }

        private void OnsItemSelected(ItemClickEventArgs args)
        {
            var selected = args.ClickedItem as SampleImage;
            ImagesNavigationHelper.AddImageId(ImageGallerySelectedIdKey, selected.ID);
            NavigationService.Frame.SetListDataItemForNextConnectedAnnimation(selected);
            NavigationService.Navigate(typeof(ImageGalleryDetailViewModel).FullName, selected.ID);
        }
    }
}
