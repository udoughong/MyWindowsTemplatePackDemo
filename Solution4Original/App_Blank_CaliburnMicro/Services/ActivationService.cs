using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using App_Blank_CaliburnMicro.Activation;
using App_Blank_CaliburnMicro.Core.Helpers;
using App_Blank_CaliburnMicro.Core.Services;
using App_Blank_CaliburnMicro.Services;

using Caliburn.Micro;

using Windows.ApplicationModel.Activation;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace App_Blank_CaliburnMicro.Services
{
    // For more information on application activation see https://github.com/Microsoft/WindowsTemplateStudio/blob/master/docs/activation.md
    internal class ActivationService
    {
        private readonly WinRTContainer _container;
        private readonly Type _defaultNavItem;
        private readonly Lazy<UIElement> _shell;

        public static KeyboardAccelerator AltLeftKeyboardAccelerator { get; private set; }

        public static KeyboardAccelerator BackKeyboardAccelerator { get; private set; }

        public ActivationService(WinRTContainer container, Type defaultNavItem, Lazy<UIElement> shell = null)
        {
            _container = container;
            _shell = shell;
            _defaultNavItem = defaultNavItem;
            AltLeftKeyboardAccelerator = BuildKeyboardAccelerator(VirtualKey.Left, VirtualKeyModifiers.Menu);
            BackKeyboardAccelerator = BuildKeyboardAccelerator(VirtualKey.GoBack);
        }

        public async Task ActivateAsync(object activationArgs)
        {
            if (IsInteractive(activationArgs))
            {
                // Initialize things like registering background task before the app is loaded
                await InitializeAsync();

                // Do not repeat app initialization when the Window already has content,
                // just ensure that the window is active
                if (Window.Current.Content == null)
                {
                    // Create a Frame to act as the navigation context and navigate to the first page
                    if (_shell?.Value == null)
                    {
                        var frame = new Frame();
                        NavigationService = _container.RegisterNavigationService(frame);
                        Window.Current.Content = frame;
                    }
                    else
                    {
                        var viewModel = ViewModelLocator.LocateForView(_shell.Value);

                        ViewModelBinder.Bind(viewModel, _shell.Value, null);

                        ScreenExtensions.TryActivate(viewModel);

                        NavigationService = _container.GetInstance<INavigationService>();
                        Window.Current.Content = _shell?.Value;
                    }

                    _container.RegisterInstance(typeof(IConnectedAnimationService), nameof(IConnectedAnimationService), new ConnectedAnimationService(Window.Current.Content as Frame));

                    if (NavigationService != null)
                    {
                        NavigationService.NavigationFailed += (sender, e) =>
                        {
                            throw e.Exception;
                        };
                    }
                }
            }

            var activationHandler = GetActivationHandlers()
                                                .FirstOrDefault(h => h.CanHandle(activationArgs));

            if (activationHandler != null)
            {
                await activationHandler.HandleAsync(activationArgs);
            }

            if (IsInteractive(activationArgs))
            {
                var defaultHandler = new DefaultLaunchActivationHandler(_defaultNavItem, NavigationService);
                if (defaultHandler.CanHandle(activationArgs))
                {
                    await defaultHandler.HandleAsync(activationArgs);
                }

                // Ensure the current window is active
                Window.Current.Activate();

                // Tasks after activation
                await StartupAsync();
            }
        }

        private INavigationService NavigationService { get; set; }

        private async Task InitializeAsync()
        {
            SampleDataService.Initialize("ms-appx:///Assets");
            WindowManagerService.Current.Initialize();
            await Singleton<BackgroundTaskService>.Instance.RegisterBackgroundTasksAsync();
            await Singleton<LiveTileService>.Instance.EnableQueueAsync();
            await ThemeSelectorService.InitializeAsync();
        }

        private async Task StartupAsync()
        {
            await ThemeSelectorService.SetRequestedThemeAsync();

            // TODO WTS: Configure and enable Azure Notification Hub integration.
            //  1. Go to the AzureNotificationsService class, in the InitializeAsync() method, provide the Hub Name and DefaultListenSharedAccessSignature.
            //  2. Uncomment the following line (an exception will be thrown if it is executed and the above information is not provided).
            // await Singleton<AzureNotificationsService>.Instance.InitializeAsync();
            await Singleton<DevCenterNotificationsService>.Instance.InitializeAsync();
            Singleton<LiveTileService>.Instance.SampleUpdate();
            await FirstRunDisplayService.ShowIfAppropriateAsync();
            await WhatsNewDisplayService.ShowIfAppropriateAsync();

            // TODO WTS: This is a sample to demonstrate how to add a UserActivity. Please adapt and move this method call to where you consider convenient in your app.
            await UserActivityService.AddSampleUserActivity();
        }

        private IEnumerable<ActivationHandler> GetActivationHandlers()
        {
            yield return Singleton<WebToAppLinkActivationHandler>.Instance;
            yield return new SchemeActivationHandler(NavigationService);
            yield return Singleton<SuspendAndResumeService>.Instance;
            yield return Singleton<ShareTargetActivationHandler>.Instance;
            yield return Singleton<BackgroundTaskService>.Instance;
            yield return Singleton<LiveTileService>.Instance;
            yield return Singleton<DevCenterNotificationsService>.Instance;
            yield return Singleton<AzureNotificationsService>.Instance;
            yield return Singleton<ToastNotificationsService>.Instance;
        }

        private bool IsInteractive(object args)
        {
            return args is IActivatedEventArgs;
        }

        private KeyboardAccelerator BuildKeyboardAccelerator(VirtualKey key, VirtualKeyModifiers? modifiers = null)
        {
            var keyboardAccelerator = new KeyboardAccelerator() { Key = key };
            if (modifiers.HasValue)
            {
                keyboardAccelerator.Modifiers = modifiers.Value;
            }

            keyboardAccelerator.Invoked += OnKeyboardAcceleratorInvoked;
            return keyboardAccelerator;
        }

        private void OnKeyboardAcceleratorInvoked(KeyboardAccelerator sender, KeyboardAcceleratorInvokedEventArgs args)
        {
            if (NavigationService.CanGoBack)
            {
                NavigationService.GoBack();
                args.Handled = true;
            }
        }

        internal async Task ActivateFromShareTargetAsync(ShareTargetActivatedEventArgs activationArgs)
        {
            var shareTargetHandler = GetActivationHandlers().FirstOrDefault(h => h.CanHandle(activationArgs));
            if (shareTargetHandler != null)
            {
                await shareTargetHandler.HandleAsync(activationArgs);
            }
        }
    }
}
