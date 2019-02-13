using System;
using System.Globalization;
using System.Threading.Tasks;

using App_Blank_Prism.Activation;
using App_Blank_Prism.Core.Services;
using App_Blank_Prism.Services;
using App_Blank_Prism.Views;

using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Microsoft.Practices.Unity;

using Prism.Mvvm;
using Prism.Unity.Windows;
using Prism.Windows.AppModel;
using Prism.Windows.Navigation;

using Windows.ApplicationModel.Activation;
using Windows.ApplicationModel.Core;
using Windows.ApplicationModel.Resources;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace App_Blank_Prism
{
    [Windows.UI.Xaml.Data.Bindable]
    public sealed partial class App : PrismUnityApplication
    {
        // Detailed documentation about Web to App link at https://docs.microsoft.com/en-us/windows/uwp/launch-resume/web-to-app-linking
        // TODO WTS: Update the Host URI here and in Package.appxmanifest XML (Right click > View Code)
        private const string Host = "myapp.website.com";
        private const string Section1 = "/MySection1";
        private const string Section2 = "/MySection2";

        public App()
        {
            // TODO WTS: Replace the default 3D Launcher model with something appropriate to your app
            // For details see https://docs.microsoft.com/en-us/windows/mixed-reality/3d-app-launcher-design-guidance
            InitializeComponent();

            // TODO WTS: Add your app in the app center and set your secret here. More at https://docs.microsoft.com/en-us/appcenter/sdk/getting-started/uwp
            AppCenter.Start("{Your App Secret}", typeof(Analytics), typeof(Crashes));
        }

        protected override void ConfigureContainer()
        {
            // register a singleton using Container.RegisterType<IInterface, Type>(new ContainerControlledLifetimeManager());
            base.ConfigureContainer();
            Container.RegisterType<IBackgroundTaskService, BackgroundTaskService>(new ContainerControlledLifetimeManager());
            Container.RegisterType<IWhatsNewDisplayService, WhatsNewDisplayService>(new ContainerControlledLifetimeManager());
            Container.RegisterType<IFirstRunDisplayService, FirstRunDisplayService>(new ContainerControlledLifetimeManager());
            Container.RegisterType<ILiveTileService, LiveTileService>(new ContainerControlledLifetimeManager());
            Container.RegisterType<IDevCenterNotificationsService, DevCenterNotificationsService>(new ContainerControlledLifetimeManager());
            Container.RegisterType<IAzureNotificationsService, AzureNotificationsService>(new ContainerControlledLifetimeManager());
            Container.RegisterType<IToastNotificationsService, ToastNotificationsService>(new ContainerControlledLifetimeManager());
            Container.RegisterInstance<IResourceLoader>(new ResourceLoaderAdapter(new ResourceLoader()));
            Container.RegisterType<IWebViewService, WebViewService>();
            Container.RegisterType<ISampleDataService, SampleDataService>();
            Container.RegisterType<ILocationService, LocationService>();
        }

        protected override async Task OnLaunchApplicationAsync(LaunchActivatedEventArgs args)
        {
            await LaunchApplicationAsync(PageTokens.MainPage, null);
        }

        private async Task LaunchApplicationAsync(string page, object launchParam)
        {
            await ThemeSelectorService.SetRequestedThemeAsync();
            var rootFrame = Window.Current.Content as Frame;
            Container.RegisterInstance<IConnectedAnimationService>(new ConnectedAnimationService(rootFrame));
            NavigationService.Navigate(page, launchParam);
            Window.Current.Activate();

            // TODO WTS: This is a sample to demonstrate how to add a UserActivity. Please adapt and move this method call to where you consider convenient in your app.
            await UserActivityService.AddSampleUserActivity();
            await Container.Resolve<IWhatsNewDisplayService>().ShowIfAppropriateAsync();
            await Container.Resolve<IFirstRunDisplayService>().ShowIfAppropriateAsync();
            Container.Resolve<ILiveTileService>().SampleUpdate();
            await Container.Resolve<IDevCenterNotificationsService>().InitializeAsync();
            await Container.Resolve<IAzureNotificationsService>().InitializeAsync();
            Container.Resolve<IToastNotificationsService>().ShowToastNotificationSample();
        }

        protected override async Task OnActivateApplicationAsync(IActivatedEventArgs args)
        {
            // By default, this handler expects URIs of the format 'wtsapp:sample?paramName1=paramValue1&paramName2=paramValue2'
            if (args.Kind == ActivationKind.Protocol && args is ProtocolActivatedEventArgs protocolArgs && protocolArgs.Uri != null)
            {
                // Create data from activation Uri in ProtocolActivatedEventArgs
                var data = new SchemeActivationData(protocolArgs.Uri);
                if (data.IsValid)
                {
                    await LaunchApplicationAsync(data.PageToken, data.Parameters);
                }
                else if (args.PreviousExecutionState != ApplicationExecutionState.Running)
                {
                    // If the app isn't running and not navigating to a specific page based on the URI, navigate to the home page
                    await OnLaunchApplicationAsync(args as LaunchActivatedEventArgs);
                }
            }

            if (args.Kind == ActivationKind.ToastNotification && args.PreviousExecutionState != ApplicationExecutionState.Running)
            {
                // Handle a dev center notification here
                // Since dev center, toast, and Azure notification hub will all active with an ActivationKind.ToastNotification
                // you may have to parse the toast data to determine where it came from and what action you want to take
                // If the app isn't running then launch the app here
                await OnLaunchApplicationAsync(args as LaunchActivatedEventArgs);
            }

            if (args.Kind == ActivationKind.ToastNotification && args.PreviousExecutionState != ApplicationExecutionState.Running)
            {
                // Handle an Azure hub notification here
                // Since dev center, toast, and Azure notification hub will all active with an ActivationKind.ToastNotification
                // you may have to parse the toast data to determine where it came from and what action you want to take
                // If the app isn't running then launch the app here
                await OnLaunchApplicationAsync(args as LaunchActivatedEventArgs);
            }

            if (args.Kind == ActivationKind.ToastNotification && args.PreviousExecutionState != ApplicationExecutionState.Running)
            {
                // Handle a toast notification here
                // Since dev center, toast, and Azure notification hub will all active with an ActivationKind.ToastNotification
                // you may have to parse the toast data to determine where it came from and what action you want to take
                // If the app isn't running then launch the app here
                await OnLaunchApplicationAsync(args as LaunchActivatedEventArgs);
            }

            if (args.Kind == ActivationKind.Protocol && ((ProtocolActivatedEventArgs)args)?.Uri?.Host == Host && args.PreviousExecutionState != ApplicationExecutionState.Running)
            {
                switch (((ProtocolActivatedEventArgs)args).Uri.AbsolutePath)
                {
                    // Open the page in app that is equivalent to the section on the website.
                    case Section1:
                        // Use NavigationService to Navigate to MySection1Page
                        break;
                    case Section2:
                        // Use NavigationService to Navigate to MySection2Page
                        break;
                    default:
                        // Launch the application with default page.
                        // Use NavigationService to Navigate to MainPage
                        break;
                }
            }

            await Task.CompletedTask;
        }

        protected override void OnBackgroundActivated(BackgroundActivatedEventArgs args)
        {
            base.OnBackgroundActivated(args);
            if (Container == null)
            {
                // Edge case where the in-process background task's activation trigger is handled when the application is just shut down.
                // Known issue: NullReferenceException in the OnSuspending method for the short application activation to handle the trigger.
                // This will be fixed in the next Prism release, more info see https://github.com/Microsoft/WindowsTemplateStudio/issues/2632
                CreateAndConfigureContainer();
            }

            Container.Resolve<IBackgroundTaskService>().Start(args.TaskInstance);
        }

        protected override async Task OnInitializeAsync(IActivatedEventArgs args)
        {
            var sampleDataService = Container.Resolve<ISampleDataService>();
            sampleDataService.Initialize("ms-appx:///Assets");
            await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(
                CoreDispatcherPriority.Normal,
                () =>
                {
                    WindowManagerService.Current.Initialize();
                });
            await ThemeSelectorService.InitializeAsync().ConfigureAwait(false);

            // We are remapping the default ViewNamePage and ViewNamePageViewModel naming to ViewNamePage and ViewNameViewModel to
            // gain better code reuse with other frameworks and pages within Windows Template Studio
            ViewModelLocationProvider.SetDefaultViewTypeToViewModelTypeResolver((viewType) =>
            {
                var viewModelTypeName = string.Format(CultureInfo.InvariantCulture, "App_Blank_Prism.ViewModels.{0}ViewModel, App_Blank_Prism", viewType.Name.Substring(0, viewType.Name.Length - 4));
                return Type.GetType(viewModelTypeName);
            });
            await Container.Resolve<ILiveTileService>().EnableQueueAsync().ConfigureAwait(false);
            await Container.Resolve<IBackgroundTaskService>().RegisterBackgroundTasksAsync();
            await base.OnInitializeAsync(args);
        }

        protected override IDeviceGestureService OnCreateDeviceGestureService()
        {
            var service = base.OnCreateDeviceGestureService();
            service.UseTitleBarBackButton = false;
            return service;
        }
    }
}
