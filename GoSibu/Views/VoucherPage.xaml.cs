using GoSibu.ViewModels;
namespace GoSibu.Views;

public partial class VoucherPage : ContentPage
{
    [Obsolete]
    public VoucherPage()
    {
        InitializeComponent();
        BindingContext = new VoucherListPageViewModel();
    }

}