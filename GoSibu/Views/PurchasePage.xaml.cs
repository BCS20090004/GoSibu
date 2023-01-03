using Shared.GoSibu.Models;
using GoSibu.ViewModels;
using Microsoft.Maui.Controls.Maps;
using AndroidX.Lifecycle;

namespace GoSibu.Views;

[XamlCompilation(XamlCompilationOptions.Compile)]

public partial class PurchasePage : ContentPage
{

    public PurchasePage(PackageModel package)
    {
        InitializeComponent();
        this.BindingContext = new ShowPackagePageViewModel(package);


    }
    async void OnMapClicked(Object sender, MapClickedEventArgs e)
    {
        //mappy.Pins.Clear();
        //mappy.Pins.Remove();
        //mappy.MapElements.Add(new Polyline() );

        var pin = new Pin()
        {
            Label = $"MapClick: {e.Location.Latitude}, {e.Location.Longitude}",
            Location = new Location(e.Location.Latitude, e.Location.Longitude),
        };

        mappy.Pins.Add(pin);
        //mappy.Pins.Add(pin);

        pin.MarkerClicked += async (s, args) =>
        {
            args.HideInfoWindow = true;
            string pinName = ((Pin)s).Label;
            var response = await DisplayActionSheet("Pin Clicked", "OK", "Remove Button", $"{pinName}");
            if (response == "Remove Button")
            {
                mappy.Pins.Remove(pin);
                BuildPath();
            }
        };

        BuildPath();
    }

        private void BuildPath()
    {
        mappy.MapElements.Clear();
        if (mappy.Pins.Count > 1)
        {
            Polyline polyline = new Polyline
            {
                StrokeColor = Colors.Blue,
                StrokeWidth = 12
            };
            //loop through markers,add the location
            for (int i = 0; i < mappy.Pins.Count; i++)
            {
                polyline.Geopath.Add(new Location(mappy.Pins[i].Location.Latitude, mappy.Pins[i].Location.Longitude));
            }
            // Add the Polyline to the map's MapElements collection
            mappy.MapElements.Add(polyline);
        }
        //mappy.Pins.Remove();

    }
    protected async override void OnAppearing()
    {
        await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
    }

        private void PaymentButton_Click(object sender, EventArgs e)
    {
        Navigation.PushAsync(new PaymentPage());
    }
}