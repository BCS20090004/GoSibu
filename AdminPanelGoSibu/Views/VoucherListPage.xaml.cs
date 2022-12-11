using AdminPanelGoSibu.ViewModels;

namespace AdminPanelGoSibu.Views;

public partial class VoucherListPage : ContentPage
{
    [Obsolete]
    public VoucherListPage()
	{
		InitializeComponent();
        this.BindingContext = new VoucherListPageViewModel();

    }
}