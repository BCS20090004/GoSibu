using AdminPanelGoSibu.ViewModels;
using Gosibu.Shared.Models;

namespace AdminPanelGoSibu.Views;

[XamlCompilation(XamlCompilationOptions.Compile)]

public partial class AddUpdatePackagePage : ContentPage
{
    public AddUpdatePackagePage()
    {
        InitializeComponent();
        this.BindingContext = new AddUpdatePackagePageViewModel();

    }

    public AddUpdatePackagePage(PackageModel package)
    {
        InitializeComponent();
        this.BindingContext = new AddUpdatePackagePageViewModel(package);

    }
}