namespace GoSibu.Models
{
    internal class EditProfile
    {
        public class UserEdit
        {
            private int id;
            private string email;
            private string usernameedit;
            private string gender;
            private double phonenumber;
            private string imagesource;
            private DateTime dateofbirth;

            public int Id
            {
                get => id;
                set
                {
                    id = value;
                }
            }
            public string Email
            {
                get => email;
                set
                {
                    email = value;
                }
            }
            public string UsernameEdit
            {
                get => usernameedit;
                set
                {
                    usernameedit = value;
                }
            }

            public string Gender
            {
                get => gender;
                set
                {
                    gender = value;
                }
            }

            public double PhoneNumber
            {
                get => phonenumber;
                set
                {
                    phonenumber = value;
                }
            }

            public string ImageSource
            {
                get => imagesource;
                set
                {
                    imagesource = value;
                }
            }

            public DateTime DateOFBirth
            {
                get => dateofbirth;
                set
                {
                    dateofbirth = value;
                }
            }

        }

    }
}
