using Firebase.Auth;
using GoSibu.Views;
using Newtonsoft.Json;
using System.ComponentModel;
using System.Windows.Input;

namespace GoSibu.ViewModels;

public class LoginPageViewModel : INotifyPropertyChanged
{
    public string webApiKey = "AIzaSyCmbHPjiVE5Uly9bnsBtxK5NGSB7qdteJ8";
    private INavigation _navigation;
    private string userName;
    private string userPassword;

    public event PropertyChangedEventHandler PropertyChanged;

    public Command RegisterBtn { get; }
    public Command LoginBtn { get; }

    public string UserName
    {
        get => userName; set
        {
            userName = value;
            RaisePropertyChanged("UserName");
        }
    }

    public string UserPassword
    {
        get => userPassword; set
        {
            userPassword = value;
            RaisePropertyChanged("UserPassword");
        }
    }

    public LoginPageViewModel(INavigation navigation)
    {
        ICommandNavToSignUpPage = new Command(() => NavigateToSignUp());
        ICommandNavToForgetPasswordPage = new Command(() => NavigateToForgetPassword());
        this._navigation = navigation;
        //RegisterBtn = new Command(RegisterBtnTappedAsync);
        LoginBtn = new Command(LoginBtnTappedAsync);
    }

    private async void LoginBtnTappedAsync(object obj)
    {
        var authProvider = new FirebaseAuthProvider(new FirebaseConfig(webApiKey));
        try
        {
            var auth = await authProvider.SignInWithEmailAndPasswordAsync(UserName, UserPassword);
            var content = await auth.GetFreshAuthAsync();
            var serializedContent = JsonConvert.SerializeObject(content);
            Preferences.Set("FreshFirebaseToken", serializedContent);
            Application.Current.MainPage = new AppShell();
            await Shell.Current.GoToAsync("//MainPage");
        }
        catch (Exception ex)
        {
            await App.Current.MainPage.DisplayAlert("Alert", ex.Message, "OK");
            throw;
        }


    }

    //private async void RegisterBtnTappedAsync(object obj)
    //{
    //    await this._navigation.PushAsync(new SignUp());
    //}

    private void RaisePropertyChanged(string v)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(v));
    }
    public ICommand ICommandNavToSignUpPage { get; set; }
    public ICommand ICommandNavToForgetPasswordPage { get; set; }

    private void NavigateToSignUp()
    {
        App.Current.MainPage.Navigation.PushAsync(new SignUp());
    }

    private void NavigateToForgetPassword()
    {
        App.Current.MainPage.Navigation.PushAsync(new ForgetPassword());
    }
    //public LoginPageViewModel()
    //{
    //    ICommandNavToSignUpPage = new Command(() => NavigateToSignUp());
    //    ICommandNavToForgetPasswordPage = new Command(() => NavigateToForgetPassword());

    //    LogInCommand = new Command(async () =>
    //    {
    //        int i = 0;
    //        var test = 5 / i;

    //        var properties = new Dictionary<string, string> {
    //                    { "Test", "123" },
    //                    { "Wifi", "On" }
    //                    };
    //        Crashes.TrackError(new InvalidDataException(), properties);
    //        if (CanLogIn)
    //        {
    //            await Shell.Current.DisplayAlert("Log in success", "", "OK");
    //        }
    //    });
    //}



    //private void NavigateToForgetPassword()
    //{
    //    App.Current.MainPage.Navigation.PushAsync(new ForgetPassword());
    //}

    //bool IsValidEmail(string email)
    //{
    //    var trimmedEmail = email.Trim();

    //    if (trimmedEmail.EndsWith("."))
    //    {
    //        return false; // suggested by @TK-421
    //    }
    //    try
    //    {
    //        var addr = new System.Net.Mail.MailAddress(email);
    //        return addr.Address == trimmedEmail;
    //    }
    //    catch
    //    {
    //        return false;
    //    }
    //}

    //public string Email { get; set; } = "";
    //public string Password { get; set; } = "";

    //public ICommand LogInCommand { get; }
    //public bool CanLogIn => IsValidEmail(Email) && !string.IsNullOrWhiteSpace(Password);
    //public event PropertyChangedEventHandler PropertyChanged;
}
