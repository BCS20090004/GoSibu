using AdminPanelGoSibu.ViewModels;
//using Android.Gms.Maps.Model;
using Gosibu.Shared.Models;
using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.Controls.Maps;
using System.Drawing;
using System.Net.NetworkInformation;
using Polyline = Microsoft.Maui.Controls.Maps.Polyline;

namespace AdminPanelGoSibu.Views;

[XamlCompilation(XamlCompilationOptions.Compile)]

public partial class AddUpdatePackagePage : ContentPage
{
    private AddUpdatePackagePageViewModel _viewModel;
    public AddUpdatePackagePage()
    {
        InitializeComponent();
        this.BindingContext = _viewModel=new AddUpdatePackagePageViewModel();
        //delegate
    }

    async void OnMapClicked(Object sender, MapClickedEventArgs e)
    {
        //mappy.Pins.Clear();
        //mappy.Pins.Remove();
        //mappy.MapElements.Add(new Polyline() );

        var pin = new Pin() {
            Label = $"MapClick: {e.Location.Latitude}, {e.Location.Longitude}",
            Location = new Location(e.Location.Latitude, e.Location.Longitude),
        };

        _viewModel.Pins.Add(pin);
        //mappy.Pins.Add(pin);

        pin.MarkerClicked += async (s, args) =>
        {
            args.HideInfoWindow = true;
            string pinName = ((Pin)s).Label;
            var response = await DisplayActionSheet("Pin Clicked", "OK", "Remove Button", $"{pinName}" );
            if(response == "Remove Button")
            {
                _viewModel.Pins.Remove(pin);
                BuildPath();
            }
        };

        BuildPath();
        //ClearPins
    }

    //private void Map_PinClicked(Object sender, PinClickedEventArgs e)
    //{
    //    var pin = sender as Pin;
    //    mappy.Pins.Remove(pin);
    //    BuildPath();
    //}

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
    public AddUpdatePackagePage(PackageModel package)
    {
        InitializeComponent();
        this.BindingContext = new AddUpdatePackagePageViewModel(package);
    }


}