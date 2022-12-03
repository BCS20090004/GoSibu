
using GoSibu.ViewModels;

namespace GoSibu.Views;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        BindingContext = new MainPageViewModel();
    }

    async void OnTapGestureRecognizerTapped(object sender, EventArgs eventArgs)
    {
        Image g = (Image)sender;
        await g.TranslateTo(-50, 0, 1000);

    }
}

