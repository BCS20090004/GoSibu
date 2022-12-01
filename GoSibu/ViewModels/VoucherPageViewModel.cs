using System.Windows.Input;
using GoSibu.Views;

namespace GoSibu.ViewModels;

public class VoucherPageViewModel
{
    public ICommand ICommandNavToUseVoucherPage { get; set; }

    public VoucherPageViewModel()
    {
        ICommandNavToUseVoucherPage = new Command(() => NavigateToUseVoucher());

    }

    private void NavigateToUseVoucher()
    {
        App.Current.MainPage.Navigation.PushAsync(new UseVoucherPage());
    }

}