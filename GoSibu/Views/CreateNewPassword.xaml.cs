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
}