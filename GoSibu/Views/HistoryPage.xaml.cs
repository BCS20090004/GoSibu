namespace GoSibu.Views;

public partial class HistoryPage : ContentPage
{
    public HistoryPage()
    {
        InitializeComponent();
    }
    async void OnTapGestureRecognizerTapped(object sender, EventArgs eventArgs)
    {
        Image g = (Image)sender;
        await g.TranslateTo(-50, 0, 1000);

    }
}