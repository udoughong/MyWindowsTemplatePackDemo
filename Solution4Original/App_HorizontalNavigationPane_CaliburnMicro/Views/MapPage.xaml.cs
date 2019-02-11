using System;

using App_HorizontalNavigationPane_CaliburnMicro.ViewModels;

using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;

namespace App_HorizontalNavigationPane_CaliburnMicro.Views
{
    public sealed partial class MapPage : Page, IMapView
    {
        public MapPage()
        {
            InitializeComponent();
        }

        private MapViewModel ViewModel
        {
            get { return DataContext as MapViewModel; }
        }

        public void AddMapIcon(Geopoint position, string title)
        {
            var mapIcon = new MapIcon()
            {
                Location = position,
                NormalizedAnchorPoint = new Point(0.5, 1.0),
                Title = title,
                Image = RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/map.png")),
                ZIndex = 0
            };

            mapControl.MapElements.Add(mapIcon);
        }
    }
}
