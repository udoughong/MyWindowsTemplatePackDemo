using System;

using App_HorizontalNavigationPane_MvvmLight.Services;
using App_HorizontalNavigationPane_MvvmLight.Views;

using GalaSoft.MvvmLight.Ioc;

namespace App_HorizontalNavigationPane_MvvmLight.ViewModels
{
    [Windows.UI.Xaml.Data.Bindable]
    public class ViewModelLocator
    {
        private static ViewModelLocator _current;

        public static ViewModelLocator Current => _current ?? (_current = new ViewModelLocator());

        private ViewModelLocator()
        {
            if (SimpleIoc.Default.IsRegistered<NavigationServiceEx>())
            {
                return;
            }

            SimpleIoc.Default.Register(() => new NavigationServiceEx());
            SimpleIoc.Default.Register<ShellViewModel>();
            Register<MainViewModel, MainPage>();
            Register<WebViewViewModel, WebViewPage>();
            Register<MediaPlayerViewModel, MediaPlayerPage>();
            Register<MasterDetailViewModel, MasterDetailPage>();
            Register<ContentGridViewModel, ContentGridPage>();
            Register<ContentGridDetailViewModel, ContentGridDetailPage>();
            Register<DataGridViewModel, DataGridPage>();
            Register<TelerikDataGridViewModel, TelerikDataGridPage>();
            Register<ChartViewModel, ChartPage>();
            Register<TabbedViewModel, TabbedPage>();
            Register<MapViewModel, MapPage>();
            Register<CameraViewModel, CameraPage>();
            Register<ImageGalleryViewModel, ImageGalleryPage>();
            Register<ImageGalleryDetailViewModel, ImageGalleryDetailPage>();
            Register<InkDrawViewModel, InkDrawPage>();
            Register<InkSmartCanvasViewModel, InkSmartCanvasPage>();
            Register<InkDrawPictureViewModel, InkDrawPicturePage>();
            Register<SettingsViewModel, SettingsPage>();
            Register<ShareTargetViewModel, ShareTargetPage>();
            Register<SchemeActivationSampleViewModel, SchemeActivationSamplePage>();
        }

        public SchemeActivationSampleViewModel SchemeActivationSampleViewModel => SimpleIoc.Default.GetInstance<SchemeActivationSampleViewModel>();

        public ShareTargetViewModel ShareTargetViewModel => SimpleIoc.Default.GetInstance<ShareTargetViewModel>();

        public SettingsViewModel SettingsViewModel => SimpleIoc.Default.GetInstance<SettingsViewModel>();

        public InkDrawPictureViewModel InkDrawPictureViewModel => SimpleIoc.Default.GetInstance<InkDrawPictureViewModel>();

        public InkSmartCanvasViewModel InkSmartCanvasViewModel => SimpleIoc.Default.GetInstance<InkSmartCanvasViewModel>();

        public InkDrawViewModel InkDrawViewModel => SimpleIoc.Default.GetInstance<InkDrawViewModel>();

        public ImageGalleryDetailViewModel ImageGalleryDetailViewModel => SimpleIoc.Default.GetInstance<ImageGalleryDetailViewModel>();

        public ImageGalleryViewModel ImageGalleryViewModel => SimpleIoc.Default.GetInstance<ImageGalleryViewModel>();

        public CameraViewModel CameraViewModel => SimpleIoc.Default.GetInstance<CameraViewModel>();

        public MapViewModel MapViewModel => SimpleIoc.Default.GetInstance<MapViewModel>();

        public TabbedViewModel TabbedViewModel => SimpleIoc.Default.GetInstance<TabbedViewModel>();

        public ChartViewModel ChartViewModel => SimpleIoc.Default.GetInstance<ChartViewModel>();

        public TelerikDataGridViewModel TelerikDataGridViewModel => SimpleIoc.Default.GetInstance<TelerikDataGridViewModel>();

        public DataGridViewModel DataGridViewModel => SimpleIoc.Default.GetInstance<DataGridViewModel>();

        public ContentGridDetailViewModel ContentGridDetailViewModel => SimpleIoc.Default.GetInstance<ContentGridDetailViewModel>();

        public ContentGridViewModel ContentGridViewModel => SimpleIoc.Default.GetInstance<ContentGridViewModel>();

        public MasterDetailViewModel MasterDetailViewModel => SimpleIoc.Default.GetInstance<MasterDetailViewModel>();

        // A Guid is generated as a unique key for each instance as reusing the same VM instance in multiple MediaPlayerElement instances can cause playback errors
        public MediaPlayerViewModel MediaPlayerViewModel => SimpleIoc.Default.GetInstance<MediaPlayerViewModel>(Guid.NewGuid().ToString());

        public WebViewViewModel WebViewViewModel => SimpleIoc.Default.GetInstance<WebViewViewModel>();

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
