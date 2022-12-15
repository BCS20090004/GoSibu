using AdminPanelGoSibu.Views;

namespace AdminPanelGoSibu;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }
    private void addPackage_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new AddUpdatePackagePage());
    }

    private void showPackage_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new PackageList());
    }
}
