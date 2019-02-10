﻿using System;
using System.Threading.Tasks;
using System.Windows.Input;

using App_Blank_CaliburnMicro.Helpers;
using App_Blank_CaliburnMicro.Services;
using App_Blank_CaliburnMicro.Views;

using Caliburn.Micro;

using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Controls.Maps;

namespace App_Blank_CaliburnMicro.ViewModels
{
    public class MapViewModel : Screen
    {
        // TODO WTS: Set your preferred default zoom level
        private const double DefaultZoomLevel = 17;

        private readonly LocationService _locationService;

        // TODO WTS: Set your preferred default location if a geolock can't be found.
        private readonly BasicGeoposition _defaultPosition = new BasicGeoposition()
        {
            Latitude = 47.609425,
            Longitude = -122.3417
        };

        private double _zoomLevel;

        public double ZoomLevel
        {
            get { return _zoomLevel; }
            set { Set(ref _zoomLevel, value); }
        }

        private Geopoint _center;

        public Geopoint Center
        {
            get { return _center; }
            set { Set(ref _center, value); }
        }

        private string _mapServiceToken;

        public string MapServiceToken
        {
            get { return _mapServiceToken; }
            set { Set(ref _mapServiceToken, value); }
        }

        public MapViewModel()
        {
            _locationService = new LocationService();
            Center = new Geopoint(_defaultPosition);
            ZoomLevel = DefaultZoomLevel;
        }

        protected override async void OnInitialize()
        {
            base.OnInitialize();

            if (_locationService != null)
            {
                _locationService.PositionChanged += LocationServicePositionChanged;

                var initializationSuccessful = await _locationService.InitializeAsync();

                if (initializationSuccessful)
                {
                    await _locationService.StartListeningAsync();
                }

                if (initializationSuccessful && _locationService.CurrentPosition != null)
                {
                    Center = _locationService.CurrentPosition.Coordinate.Point;
                }
                else
                {
                    Center = new Geopoint(_defaultPosition);
                }
            }

            // TODO WTS: Set your map service token. If you don't have one, request from https://www.bingmapsportal.com/
            // MapServiceToken = string.Empty;
            var view = GetView() as IMapView;

            view?.AddMapIcon(Center, "Map_YourLocation".GetLocalized());
        }

        protected override void OnDeactivate(bool close)
        {
            base.OnDeactivate(close);

            if (_locationService != null)
            {
                _locationService.PositionChanged -= LocationServicePositionChanged;
                _locationService.StopListening();
            }
        }

        private void LocationServicePositionChanged(object sender, Geoposition geoposition)
        {
            if (geoposition != null)
            {
                Center = geoposition.Coordinate.Point;
            }
        }
    }
}
