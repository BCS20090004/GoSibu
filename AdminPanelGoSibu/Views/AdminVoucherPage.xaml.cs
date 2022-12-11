using AdminPanelGoSibu.Views;
using Gosibu.Shared.Models;
using AdminPanelGoSibu.Services;

namespace AdminPanelGoSibu;

public partial class AdminVoucherPage : ContentPage
{
    public AdminVoucherPage()
    {
        InitializeComponent();
    }

    private void Addvoucher_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new AddUpdateVoucherPage());
    }

    private void Showvoucher_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new VoucherListPage());
    }

    private async void OnCounterClicked(object sender, EventArgs e)
    {
        var service = new IVoucherService(); // originally is VoucherModel
        try
        {
            var VoucherList = await service.GetAllVoucher();
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
        }
    }
}

    