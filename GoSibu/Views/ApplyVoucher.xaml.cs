using Gosibu.Shared.Models;
using GoSibu.ViewModels;
using Microsoft.Maui.Controls.Maps;

namespace GoSibu.Views;

public partial class ApplyVoucher : ContentPage
{
    [Obsolete]
    public ApplyVoucher()
    {
        InitializeComponent();
        BindingContext = new VoucherListPageViewModel();

    }

    async void Applied(object sender, EventArgs e)
    {
        var response = await App.Current.MainPage.DisplayActionSheet("Apply Voucher?", "Yes", "No", "Comfirm Apply for this voucher.");
        if (response == "Yes")
        {
            await App.Current.MainPage.DisplayAlert("Done!", "This Voucher has been used", "OK");
        }
        else if (response == "No")
        {
            await App.Current.MainPage.Navigation.PushAsync(new PaymentPage());
        }
    }
}