using GoSibu.Views;
using System.Windows.Input;

namespace GoSibu.ViewModels;

public class MainPageViewModel
{
    public ICommand ICommandNavToPurchasePage { get; set; }

    public MainPageViewModel()
    {
        ICommandNavToPurchasePage = new Command(() => NavigateToPurchase());

    }

    private void NavigateToPurchase()
    {
        App.Current.MainPage.Navigation.PushAsync(new PurchasePage());
    }

}

