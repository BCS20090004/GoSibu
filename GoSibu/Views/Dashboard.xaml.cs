﻿using Newtonsoft.Json;

namespace GoSibu.Views
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Dashboard : ContentPage
    {
        public Dashboard()
        {
            InitializeComponent();
            GetProfileInfo();
        }

        private void GetProfileInfo()
        {
            var userInfo = JsonConvert.DeserializeObject<Firebase.Auth.FirebaseAuth>(Preferences.Get("FreshFirebaseToken", "AccessTokenKey"));
            UserEmail.Text = userInfo.User.Email;
        }
    }
}