using GoSibu.ViewModels;

namespace GoSibu;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
        BindingContext = new LoginPageViewModel(Navigation);

    }

    //private async void Login_Clicked(object sender, EventArgs e)
    //{
    //    Application.Current.MainPage = new AppShell();
    //    await Shell.Current.GoToAsync("//MainPage");
    //}

}