using AdminPanelGoSibu.ViewModels;

namespace AdminPanelGoSibu.Views;

public partial class VoucherListPage : ContentPage
{
	public VoucherListPage()
	{
		InitializeComponent();
        this.BindingContext = new VoucherListPageViewModel();

    }
}