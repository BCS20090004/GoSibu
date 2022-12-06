using GoSibu.Model;
using GoSibu.Views;
using System.Collections.ObjectModel;
using System.Windows.Input;


namespace GoSibu.ViewModels;

public class MainPageViewModel:BaseViewModel
{
    #region Properties

    private string _buttonText = "Next";
    public string ButtonText
    {
        get => _buttonText;
        set => SetProperty(ref _buttonText, value);
    }

    private int _position;
    public int Position
    {
        get => _position;
        set => SetProperty(ref _position, value, onChanged: (() =>
        {
            if (value == MainPage.Count - 1)
            {
                ButtonText = "Start";
            }
            else
            {
                ButtonText = "Next";
            }
        }));
    }

    public ObservableCollection<AdpageModel> MainPage { get; set; } = new ObservableCollection<AdpageModel>();
    #endregion
    public ICommand ICommandNavToPurchasePage { get; set; }

    public MainPageViewModel()
    {
        ICommandNavToPurchasePage = new Command(() => NavigateToPurchase());

        MainPage.Add(new AdpageModel
        {
            IntroImage = "ad2"
        });

        MainPage.Add(new AdpageModel
        {
          
            IntroImage = "ad1"
        });

        MainPage.Add(new AdpageModel
        {
            
            IntroImage = "ad3"
        });
    }

    public ICommand NextCommand => new Command(async () =>
    {
        if (Position >= MainPage.Count - 1)
        {
            await AppShell.Current.GoToAsync($"//{nameof(Dashboard)}");
        }
        else
        {
            Position += 1;
        }
    });

    private void NavigateToPurchase()
    {
        App.Current.MainPage.Navigation.PushAsync(new PurchasePage());
    }

}

