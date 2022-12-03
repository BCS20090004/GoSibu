using Microsoft.Maui.Controls;

namespace GoSibu.Views;

public partial class ForgetPassword : ContentPage
{

    public ForgetPassword()
    {

        InitializeComponent();
    }

    private void SubmitEmail_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new VerifyEmail());

    }

    async void OnTapGestureRecognizerTapped (object sender, EventArgs eventArgs)
    {
        Image g = (Image)sender;
        await g.TranslateTo(-100, 0, 1000);

    }

}