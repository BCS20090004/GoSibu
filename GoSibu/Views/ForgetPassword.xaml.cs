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
}