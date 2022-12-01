namespace GoSibu.Views;

public partial class UseVoucherPage : ContentPage
{
    public UseVoucherPage()
    {
        InitializeComponent();
    }

    private async void UseVoucher_Clicked(object sender, EventArgs e)
    {
        Application.Current.MainPage = new AppShell();
        await Shell.Current.GoToAsync("//MainPage");
    }


}