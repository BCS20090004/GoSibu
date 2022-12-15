using AdminPanelGoSibu.ViewModels;

namespace AdminPanelGoSibu.Views;

public partial class PackageList : ContentPage
{
	public PackageList()
	{
		InitializeComponent();
        this.BindingContext = new PackageListPageViewModel();

    }
}