using System;
using System.Threading.Tasks;

using App_HorizontalNavigationPane_MvvmLight.Views;

using Microsoft.Toolkit.Uwp.Helpers;

namespace App_HorizontalNavigationPane_MvvmLight.Services
{
    public static class FirstRunDisplayService
    {
        private static bool shown = false;

        internal static async Task ShowIfAppropriateAsync()
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
