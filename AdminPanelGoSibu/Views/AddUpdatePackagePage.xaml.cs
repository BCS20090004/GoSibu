using AdminPanelGoSibu.ViewModels;
using Gosibu.Shared.Models;
using Microsoft.Maui.Controls.Maps;

namespace AdminPanelGoSibu.Views;

[XamlCompilation(XamlCompilationOptions.Compile)]

public partial class AddUpdatePackagePage : ContentPage
{
    public AddUpdatePackagePage()
    {
        InitializeComponent();
        this.BindingContext = new AddUpdatePackagePageViewModel();
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
    public AddUpdatePackagePage(PackageModel package)
    {
        InitializeComponent();
        this.BindingContext = new AddUpdatePackagePageViewModel(package);

    }
}