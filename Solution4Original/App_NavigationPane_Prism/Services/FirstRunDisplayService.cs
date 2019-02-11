﻿using System;
using System.Threading.Tasks;

using App_NavigationPane_Prism.Views;

using Microsoft.Toolkit.Uwp.Helpers;

namespace App_NavigationPane_Prism.Services
{
    public class FirstRunDisplayService : IFirstRunDisplayService
    {
        private static bool shown = false;

        public async Task ShowIfAppropriateAsync()
        {
            if (SystemInformation.IsFirstRun && !shown)
            {
                shown = true;
                var dialog = new FirstRunDialog();
                await dialog.ShowAsync();
            }
        }
    }
}
