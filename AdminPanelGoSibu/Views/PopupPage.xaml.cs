using CommunityToolkit.Maui.Views;

namespace AdminPanelGoSibu.Views;

public partial class PopupPage :Popup
{
	public PopupPage()
	{
		InitializeComponent();
	}
    private void Cancel_Clicked(object sender, EventArgs e)
    {
        Close();
    }

    public async void OK_Clicked(object sender, EventArgs e)
    {
        Application.Current.MainPage = new AppShell();
        await Shell.Current.GoToAsync("//VoucherPage");
    }
}