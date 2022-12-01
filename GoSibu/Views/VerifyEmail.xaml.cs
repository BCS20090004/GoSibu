
namespace GoSibu.Views;

public partial class VerifyEmail : ContentPage
{
    public VerifyEmail()
    {
        InitializeComponent();
    }

    private void VerifyEmail_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Create_New_Password());
    }
    public ColumnDefinitionCollection ColumnDefinitions { get; }

}