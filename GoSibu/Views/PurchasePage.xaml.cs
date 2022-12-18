using Gosibu.Shared.Models;
using GoSibu.ViewModels;
using Microsoft.Maui.Controls.Maps;

namespace GoSibu.Views;

public partial class PurchasePage : ContentPage
{

    public PurchasePage(PackageModel package)
    {
        InitializeComponent();
        this.BindingContext = new ShowPackagePageViewModel(package);

        mappy.Pins.Add(new Microsoft.Maui.Controls.Maps.Pin
        {
            Label = "Sibu Is Here",
            Location = new Location(2.287778, 111.830833),
        });

    }
    async void OnMapClicked(object sender, MapClickedEventArgs e)
    {
        await App.Current.MainPage.DisplayAlert("Success!", $"MapClick: {e.Location.Latitude}, {e.Location.Longitude}", "Ok");
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