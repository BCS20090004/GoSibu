using CommunityToolkit;
using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Maps;

namespace AdminPanelGoSibu;

public partial class EditPackagePage : ContentPage
{
    public EditPackagePage()
    {
        InitializeComponent();

    }

    private async void Complete_Clicked(object sender, EventArgs e)
    {
        Application.Current.MainPage = new AppShell();
        await Shell.Current.GoToAsync("//MainPage");
    }
    protected async override void OnAppearing()
    {
        await Permissions.RequestAsync<Permissions.LocationWhenInUse>();

    }



}