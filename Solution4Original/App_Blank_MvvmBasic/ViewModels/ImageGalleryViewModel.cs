using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

using App_Blank_MvvmBasic.Core.Models;
using App_Blank_MvvmBasic.Core.Services;
using App_Blank_MvvmBasic.Helpers;
using App_Blank_MvvmBasic.Services;
using App_Blank_MvvmBasic.Views;

using Microsoft.Toolkit.Uwp.UI.Animations;

using Windows.UI.Xaml.Controls;

namespace App_Blank_MvvmBasic.ViewModels
{
    public class ImageGalleryViewModel : Observable
    {
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
            NavigationService.Navigate<ImageGalleryDetailPage>(selected.ID);
        }
    }
}
