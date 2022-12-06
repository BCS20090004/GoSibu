using Firebase.Auth;
using GoSibu.Views;
using Newtonsoft.Json;
using System.ComponentModel;
using System.Windows.Input;

namespace GoSibu.ViewModels;

internal class SignUpPageViewModel : INotifyPropertyChanged
{
    public ICommand ICommandNavToLoginPage { get; set; }

    public string webApiKey = "AIzaSyCmbHPjiVE5Uly9bnsBtxK5NGSB7qdteJ8";

    private INavigation _navigation;
    private string email;
    private string password;

    public event PropertyChangedEventHandler PropertyChanged;

    public string Email
    {
        get => email;
        set
        {
            email = value;
            RaisePropertyChanged("Email");
        }
    }

    public string Password
    {
        get => password; set
        {
            password = value;
            RaisePropertyChanged("Password");
        }
    }

    public Command RegisterUser { get; }

    private void RaisePropertyChanged(string v)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(v));
    }

    public SignUpPageViewModel(INavigation navigation)
    {
        ICommandNavToLoginPage = new Command(() => NavigateToLogInPage());

        this._navigation = navigation;

        RegisterUser = new Command(RegisterUserTappedAsync);
    }

    private void NavigateToLogInPage()
    {
        App.Current.MainPage.Navigation.PushAsync(new LoginPage());
    }
    private async void RegisterUserTappedAsync(object obj)
    {
        try
        {
            var authProvider = new FirebaseAuthProvider(new FirebaseConfig(webApiKey));
            var auth = await authProvider.CreateUserWithEmailAndPasswordAsync(Email, Password);
            string token = auth.FirebaseToken;
            if (token != null)
                await App.Current.MainPage.DisplayAlert("Alert", "User Registered successfully", "OK");
            await this._navigation.PopAsync();
        }
        catch (Exception ex)
        {
            await App.Current.MainPage.DisplayAlert("Alert", ex.Message, "OK");
            throw;
        }
    }
}