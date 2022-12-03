//using AdminPanelGoSibu.ViewModels;
using GoSibu.ViewModels;
namespace GoSibu.Views;

public partial class VoucherPage : ContentPage
{
    public VoucherPage()
    {
        InitializeComponent();
        //BindingContext = new VoucherListPageViewModel();
    }
    async void OnTapGestureRecognizerTapped(object sender, EventArgs eventArgs)
    {
        Image g = (Image)sender;
        await g.TranslateTo(-50, 0, 1000);

    }
}