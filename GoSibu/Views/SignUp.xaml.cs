using GoSibu.ViewModels;

namespace GoSibu.Views;

public partial class SignUp : ContentPage
{
    public SignUp()
    {
        InitializeComponent();
        BindingContext = new SignUpPageViewModel(Navigation);
    }
    //private void CreateAccount_Clicked(object sender, EventArgs e)
    //{
    //    Navigation.PushAsync(new LoginPage());
    //}
}