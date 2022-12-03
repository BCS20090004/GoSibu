using AdminPanelGoSibu.Views;
using Firebase.Database;
using System.Collections.ObjectModel;

namespace AdminPanelGoSibu;

public partial class AdminVoucherPage : ContentPage
{
    public AdminVoucherPage()
    {
        InitializeComponent();
    }

    private void addvoucher_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new AddUpdateVoucherPage());
    }

    private void showvoucher_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new VoucherListPage());
    }
}

    