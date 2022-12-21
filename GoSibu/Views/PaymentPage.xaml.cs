using Gosibu.Shared.Models;
using GoSibu.ViewModels;

namespace GoSibu.Views;

public partial class PaymentPage : ContentPage
{
	public PaymentPage()
	{
		InitializeComponent();
	}

    private void ApplyVoucher_clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new ApplyVoucher());
    }
}