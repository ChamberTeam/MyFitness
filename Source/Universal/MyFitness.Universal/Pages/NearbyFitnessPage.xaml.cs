using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace MyFitness.Universal.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
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
