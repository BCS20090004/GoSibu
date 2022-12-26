using FirebaseAdmin.Auth;

namespace AdminPanelGoSibu;

public partial class AdminAccountPage : ContentPage
{
    private string uid;

    public AdminAccountPage()
    {
        InitializeComponent();
        //UserRecord userRecord = await FirebaseAuth.DefaultInstance.GetUserAsync(uid);
        //// See the UserRecord reference doc for the contents of userRecord.
        //Console.WriteLine($"Successfully fetched user data: {userRecord.Uid}");
    }

}