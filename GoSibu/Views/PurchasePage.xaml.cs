namespace GoSibu.Views;

public partial class PurchasePage : ContentPage
{
    public PurchasePage()
    {
        InitializeComponent();
    }
    //protected override void OnNavigatedTo(NavigatedToEventArgs args)
    //{
    //    base.OnNavigatedTo(args);

    //    var hanaLoc = new Location(20.7557, -155.9880);

    //    MapSpan mapSpan = MapSpan.FromCenterAndRadius(hanaLoc, Distance.FromKilometers(3));
    //    map.MoveToRegion(mapSpan);
    //    map.Pins.Add(new Pin
    //    {
    //        Label = "Welcome to .NET MAUI!",
    //        Location = hanaLoc,
    //    });
    //}
    private void Purchase_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new PurchasePage());
    }

}