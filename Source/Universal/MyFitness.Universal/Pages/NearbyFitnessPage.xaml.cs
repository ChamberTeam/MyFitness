namespace MyFitness.Universal.Pages
{
    using System;
    using Windows.Devices.Geolocation;
    using Windows.UI.Xaml.Controls;

    public sealed partial class NearbyFitnessPage : Page
    {
        private Geolocator geolocator;
        private Uri uri;

        public NearbyFitnessPage()
        {
            this.InitializeComponent();

            this.InitGeoLocation();
        }

        private async void InitGeoLocation()
        {
            var accessStatus = await Geolocator.RequestAccessAsync();
            this.geolocator = new Geolocator();
            var geoposition = await geolocator.GetGeopositionAsync();
            var latitude = geoposition.Coordinate.Latitude;
            var longtitude = geoposition.Coordinate.Longitude;

            // https://msdn.microsoft.com/en-us/library/dn217138.aspx
            // http://www.bing.com/maps/default.aspx?ss=yp.Fitness~sst.1~pg.2
            var address = string.Format("https://www.google.com/maps/search/Fitness/@{0},{1},15z", latitude, longtitude);
            this.uri = new Uri(address);
            this.webBrowser.Navigate(uri);
        }
    }
}
