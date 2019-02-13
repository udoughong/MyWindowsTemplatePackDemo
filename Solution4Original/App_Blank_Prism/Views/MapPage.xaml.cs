using System;

using App_Blank_Prism.ViewModels;

using Windows.UI.Xaml.Controls;

namespace App_Blank_Prism.Views
{
    public sealed partial class MapPage : Page
    {
        private MapViewModel ViewModel => DataContext as MapViewModel;

        public MapPage()
        {
            InitializeComponent();
        }
    }
}
