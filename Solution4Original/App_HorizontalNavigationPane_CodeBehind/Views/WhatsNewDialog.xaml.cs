﻿using System;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace App_HorizontalNavigationPane_CodeBehind.Views
{
    public sealed partial class WhatsNewDialog : ContentDialog
    {
        public WhatsNewDialog()
        {
            // TODO WTS: Update the contents of this dialog every time you release a new version of the app
            RequestedTheme = (Window.Current.Content as FrameworkElement).RequestedTheme;
            InitializeComponent();
        }
    }
}
