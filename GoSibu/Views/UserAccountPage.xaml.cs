using Android.Widget;
using static GoSibu.Models.EditProfile;

namespace GoSibu.Views;

public partial class UserAccountPage : ContentPage
{
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

    protected override void OnAppearing()
    {
        base.OnAppearing();

        if (this.AnimationIsRunning("TransitionAnimation"))
            return;

        var parentAnimation = new Animation();

        //Planets Animation
        parentAnimation.Add(0.2, 0.5, new Animation(v => image.Opacity = v, 0, 1, Easing.CubicIn));
        parentAnimation.Add(0.1, 0.6, new Animation(v => username.Opacity = v, 0, 1, Easing.CubicIn));
        parentAnimation.Add(0.1, 0.6, new Animation(v => UserNameEdit.Opacity = v, 0, 1, Easing.CubicIn));
        parentAnimation.Add(0.1, 0.5, new Animation(v => gender.Opacity = v, 0, 1, Easing.CubicIn));
        parentAnimation.Add(0.1, 0.5, new Animation(v => UserGender.Opacity = v, 0, 1, Easing.CubicIn));
        parentAnimation.Add(0.1, 0.4, new Animation(v => email.Opacity = v, 0, 1, Easing.CubicIn));
        parentAnimation.Add(0.1, 0.4, new Animation(v => UserEmail.Opacity = v, 0, 1, Easing.CubicIn));
        parentAnimation.Add(0.1, 0.3, new Animation(v => phonenumber.Opacity = v, 0, 1, Easing.CubicIn));
        parentAnimation.Add(0.1, 0.3, new Animation(v => UserPhoneNumber.Opacity = v, 0, 1, Easing.CubicIn));
        parentAnimation.Add(0.1, 0.2, new Animation(v => time.Opacity = v, 0, 1, Easing.CubicIn));
        parentAnimation.Add(0.1, 0.2, new Animation(v => lblname.Opacity = v, 0, 1, Easing.CubicIn));
        parentAnimation.Add(0.2, 0.3, new Animation(v => btn1.Opacity = v, 0, 1, Easing.CubicIn));
        parentAnimation.Add(0.2, 0.3, new Animation(v => btn2.Opacity = v, 0, 1, Easing.CubicIn));
        //Commit the animation
        parentAnimation.Commit(this, "TransitionAnimation", 16, 3000, null, null);
    }
}