using AdminPanelGoSibu.ViewModels;
using Gosibu.Shared.Models;

namespace AdminPanelGoSibu;

[XamlCompilation(XamlCompilationOptions.Compile)]

public partial class AddUpdateVoucherPage : ContentPage
{

    public AddUpdateVoucherPage()
    {
        InitializeComponent();
        this.BindingContext = new AddUpdateVoucherPageViewModel();

    }

    public AddUpdateVoucherPage(VoucherModel voucher)
    {
        InitializeComponent();
        this.BindingContext = new AddUpdateVoucherPageViewModel(voucher);

    }

    //public AddUpdateVoucherPage(VoucherModel voucher)
    //{
    //    InitializeComponent();
    //    this.BindingContext = new AddUpdateVoucherPageViewModel(voucher);
    //}



}