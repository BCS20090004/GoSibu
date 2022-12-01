using static GoSibu.Models.EditProfile;

namespace GoSibu.Views;

public partial class AccountPage : ContentPage
{


    private readonly UserEdit User;

    public AccountPage()
    {
        InitializeComponent();
        User = new UserEdit
        {
            Id = 1,
            Gender = "Female",
            Email = "feliciakkx@gmail.com",
            ImageSource = "user1.png",
            DateOFBirth = new DateTime(2001, 9, 24),
            UsernameEdit = "Apple",
            PhoneNumber = 01120066491
        };

        UserImage.Source = User.ImageSource;
        UsernameEdit.Text = User.UsernameEdit;
        UserGender.Text = User.Gender;
        UserEmail.Text = User.Email;
        UserPhoneNumber.Text = User.PhoneNumber.ToString();
        UserDateOFBirth.Date = User.DateOFBirth;
    }

    private async void SaveProfileButton_OnClicked(object sender, EventArgs e)
    {

        User.ImageSource = UserImage.Source.ToString();
        User.UsernameEdit = UsernameEdit.Text;
        User.Gender = UserGender.Text;
        User.Email = UserEmail.Text;
        User.PhoneNumber = double.Parse(UserPhoneNumber.Text);
        User.DateOFBirth = UserDateOFBirth.Date;

        await DisplayAlert("Success", "Edit saved", "Done");

        Application.Current.MainPage = new AppShell();
        await Shell.Current.GoToAsync("//UserAccountPage");
    }

    private void AccountEdit_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new AccountPageEdit());
    }
}