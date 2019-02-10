using System;
using System.Collections.Generic;

using App_Blank_CaliburnMicro.Core.Helpers;
using App_Blank_CaliburnMicro.Services;
using App_Blank_CaliburnMicro.ViewModels;

using Caliburn.Micro;

using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;

using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;

namespace App_Blank_CaliburnMicro
{
    [Windows.UI.Xaml.Data.Bindable]
    public sealed partial class App
    {
        private Lazy<ActivationService> _activationService;

        private ActivationService ActivationService
        {
            get { return _activationService.Value; }
        }

        public App()
        {
            // TODO WTS: Replace the default 3D Launcher model with something appropriate to your app
            // For details see https://docs.microsoft.com/en-us/windows/mixed-reality/3d-app-launcher-design-guidance
            InitializeComponent();

            EnteredBackground += App_EnteredBackground;
            Resuming += App_Resuming;

            // TODO WTS: Add your app in the app center and set your secret here. More at https://docs.microsoft.com/en-us/appcenter/sdk/getting-started/uwp
            AppCenter.Start("{Your App Secret}", typeof(Analytics), typeof(Crashes));

            Initialize();

            // Deferred execution until used. Check https://msdn.microsoft.com/library/dd642331(v=vs.110).aspx for further info on Lazy<T> class.
            _activationService = new Lazy<ActivationService>(CreateActivationService);
        }

        protected override async void OnLaunched(LaunchActivatedEventArgs args)
        {
            if (!args.PrelaunchActivated)
            {
                await ActivationService.ActivateAsync(args);
            }
        }

        protected override async void OnActivated(IActivatedEventArgs args)
        {
            await ActivationService.ActivateAsync(args);
        }

        private WinRTContainer _container;

        protected override void Configure()
        {
            // This configures the framework to map between MainViewModel and MainPage
            // Normally it would map between MainPageViewModel and MainPage
            var config = new TypeMappingConfiguration
            {
                IncludeViewSuffixInViewModelNames = false
            };

            ViewLocator.ConfigureTypeMappings(config);
            ViewModelLocator.ConfigureTypeMappings(config);

            _container = new WinRTContainer();
            _container.RegisterWinRTServices();

            _container.PerRequest<MainViewModel>();
            _container.PerRequest<WebViewViewModel>();
            _container.PerRequest<MediaPlayerViewModel>();
            _container.PerRequest<MasterDetailViewModel>();
            _container.PerRequest<ContentGridDetailViewModel>();
            _container.PerRequest<ContentGridViewModel>();
            _container.PerRequest<DataGridViewModel>();
            _container.PerRequest<TelerikDataGridViewModel>();
            _container.PerRequest<ChartViewModel>();
            _container.PerRequest<TabbedViewModel>();
            _container.PerRequest<MapViewModel>();
            _container.PerRequest<CameraViewModel>();
            _container.PerRequest<ImageGalleryDetailViewModel>();
            _container.PerRequest<ImageGalleryViewModel>();
            _container.PerRequest<InkDrawViewModel>();
            _container.PerRequest<InkSmartCanvasViewModel>();
            _container.PerRequest<InkDrawPictureViewModel>();
            _container.PerRequest<SettingsViewModel>();
            _container.PerRequest<ShareTargetViewModel>();
            _container.PerRequest<SchemeActivationSampleViewModel>();
        }

        protected override object GetInstance(Type service, string key)
        {
            return _container.GetInstance(service, key);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return _container.GetAllInstances(service);
        }

        protected override void BuildUp(object instance)
        {
            _container.BuildUp(instance);
        }

        private ActivationService CreateActivationService()
        {
            return new ActivationService(_container, typeof(ViewModels.MainViewModel));
        }

        protected override async void OnBackgroundActivated(BackgroundActivatedEventArgs args)
        {
            await ActivationService.ActivateAsync(args);
        }

        protected override async void OnShareTargetActivated(ShareTargetActivatedEventArgs args)
        {
            await ActivationService.ActivateFromShareTargetAsync(args);
        }

        private async void App_EnteredBackground(object sender, EnteredBackgroundEventArgs e)
        {
            var deferral = e.GetDeferral();
            await Singleton<SuspendAndResumeService>.Instance.SaveStateAsync();
            deferral.Complete();
        }

        private void App_Resuming(object sender, object e)
        {
            Singleton<SuspendAndResumeService>.Instance.ResumeApp();
        }
    }
}
