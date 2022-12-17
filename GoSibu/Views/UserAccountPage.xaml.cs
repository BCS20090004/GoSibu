using static GoSibu.Models.EditProfile;

namespace GoSibu.Views;

public partial class UserAccountPage : ContentPage
{


    private readonly UserEdit User;
    async void OnTapGestureRecognizerTapped(object sender, EventArgs eventArgs)
    {
        Image g = (Image)sender;
        await g.TranslateTo(-40, 0, 1000);

    }

    public UserAccountPage()
    {
        InitializeComponent();
        UserNameEdit.Text = Preferences.Get("UserName", string.Empty);
        UserGender.Text = Preferences.Get("Gender", string.Empty);
        UserEmail.Text = Preferences.Get("Email", string.Empty);
        UserPhoneNumber.Text = Preferences.Get("PhoneNumber", string.Empty);
        lblname.Text = Preferences.Get("LastLogin", DateTime.Now.ToString());
    }

    void Button_Clicked(System.Object sender, System.EventArgs e)
    {
        Preferences.Set("UserName", UserNameEdit.Text);
        Preferences.Set("Gender", UserGender.Text);;
        Preferences.Set("Email", UserEmail.Text); ;
        Preferences.Set("PhoneNumber", UserPhoneNumber.Text); ;
        Preferences.Set("LastLogin", DateTime.Now.ToString());
    }

    void Button_Clicked_1(System.Object sender, System.EventArgs e)
    {
        Preferences.Clear();
    }

}