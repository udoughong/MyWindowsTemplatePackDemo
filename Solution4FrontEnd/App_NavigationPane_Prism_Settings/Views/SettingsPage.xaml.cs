using System;

using App_NavigationPane_Prism_Settings.ViewModels;

using Windows.UI.Xaml.Controls;

namespace App_NavigationPane_Prism_Settings.Views
{
    // TODO WTS: Change the URL for your privacy policy in the Resource File, currently set to https://YourPrivacyUrlGoesHere
    public sealed partial class SettingsPage : Page
    {
        private SettingsViewModel ViewModel => DataContext as SettingsViewModel;

        public SettingsPage()
        {
            InitializeComponent();
        }
    }
}
