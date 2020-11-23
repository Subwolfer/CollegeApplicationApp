using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StudentApplicationApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LogInPage : ContentPage
    {
        public LogInPage()
        {
            InitializeComponent();
        }

        private async void LogInButtonClicked(object sender, EventArgs e)
        {
            if (ValidateLogIn(EmailField.Text, PasswordField.Text))
            {
                await Navigation.PushAsync(new StudentMainPage());
            }
        }

        private async void CreateAccountButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CreateAccount());
        }

        private bool ValidateLogIn(string email, string password)
        {
            if (string.IsNullOrEmpty(email))
            {
                DisplayAlert("Missing Email", "Please enter your email address", "OK");
                return false;
            }

            if (string.IsNullOrEmpty(password))
            {
                DisplayAlert("Missing Password", "Please enter your password", "OK");
                return false;
            }

            RetrieveAccountFromDatabase(email, password);

            return true;
        }

        private bool RetrieveAccountFromDatabase(string email, string password)
        {
            return true;
        }
    }
}