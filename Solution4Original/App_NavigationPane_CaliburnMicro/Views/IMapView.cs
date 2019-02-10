using System;

using Windows.Devices.Geolocation;

namespace App_NavigationPane_CaliburnMicro.Views
{
    public interface IMapView
    {
        void AddMapIcon(Geopoint position, string title);
    }
}
