namespace GoSibu.Views;

public partial class Create_New_Password : ContentPage
{
    public Create_New_Password()
    {
        InitializeComponent();
    }

    private void ComfirmNewPass_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new LoginPage());
    }
    async void OnTapGestureRecognizerTapped(object sender, EventArgs eventArgs)
    {
        Image g = (Image)sender;
        await g.TranslateTo(-100, 0, 1000);

    }
}