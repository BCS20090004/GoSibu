
using GoSibu.ViewModels;

namespace GoSibu.Views;

public partial class MainPage : ContentPage
{
    [Obsolete]
    public MainPage()
    {
        InitializeComponent();
       this.BindingContext = new PackageListPageViewModel();
    }

    public async void OnTapGestureRecognizerTapped(object sender, EventArgs eventArgs)
    {
        Image g = (Image)sender;
        await g.TranslateTo(-50, 0, 1000);

    }
}

