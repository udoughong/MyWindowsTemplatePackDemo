using System;

using Windows.Devices.Geolocation;

namespace App_Blank_CaliburnMicro.Views
{
    public interface IMapView
    {
        void AddMapIcon(Geopoint position, string title);
    }
}
