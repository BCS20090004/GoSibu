using Gosibu.Shared.Models;
using GoSibu.ViewModels;

namespace GoSibu.Views;

public partial class UseVoucherPage : ContentPage
{
    public UseVoucherPage(VoucherModel voucher)
    {
        InitializeComponent();
        this.BindingContext = new ShowVoucherPageViewModel(voucher);

    }

}