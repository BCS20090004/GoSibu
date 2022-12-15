using Gosibu.Shared.Models;
using GoSibu.ViewModels;

namespace GoSibu.Views;

public partial class PurchasePage : ContentPage
{
    public PurchasePage(PackageModel package)
    {
        InitializeComponent();
        this.BindingContext = new ShowPackagePageViewModel(package);

    }

}