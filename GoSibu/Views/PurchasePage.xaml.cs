using Shared.GoSibu.Models;
using GoSibu.ViewModels;
using Microsoft.Maui.Controls.Maps;
using AndroidX.Lifecycle;

namespace GoSibu.Views;

public partial class PurchasePage : ContentPage
{
    private ShowPackagePageViewModel _viewModel;
    public PurchasePage(PackageModel package)
    {
        InitializeComponent();
        this.BindingContext = _viewModel=new ShowPackagePageViewModel(package);

    }
    async void OnMapClicked(Object sender, MapClickedEventArgs e)
    {
        var pin = new Pin()
        {
            Label = $"Location {_viewModel.Pins.Count + 1}",
            Location = new Location(e.Location.Latitude, e.Location.Longitude),
        };
        _viewModel.Pins.Add(pin);
        BuildPath();
    }
    private async void Map_PinClicked(Object sender, PinClickedEventArgs args)
    {
        args.HideInfoWindow = true;
        var pin = sender as Pin;
        string pinName = pin.Label;
        var response = await DisplayActionSheet("Pin Clicked", "OK", "Remove Button", $"{pinName}");
        if (response == "Remove Button")
        {
            _viewModel.Pins.Remove(pin);
            BuildPath();
        }
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