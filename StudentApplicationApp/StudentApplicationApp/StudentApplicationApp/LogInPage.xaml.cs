using StudentApplicationApp.Persistence;
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

        private void LogInButtonClicked(object sender, EventArgs e)
        {
            ValidateLogIn(EmailField.Text, PasswordField.Text);
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

        private async void RetrieveAccountFromDatabase(string email, string password)
        {
            var connection = DependencyService.Get<ISQLiteDb>().GetConnection();

            var personsCollection = await connection.QueryAsync<Student>($"select * from Person where Email = \"{email}\"");

            if (personsCollection.Any())
            {
                Student user = personsCollection[0];
                if (user.Password == password)
                {
                    if (user.isStaff)
                    {
                        Staff userStaff = new Staff
                        {
                            Email = user.Email,
                            Password = user.Password,
                            isStaff = true,
                        };

                        await Navigation.PushAsync(new StaffMainPage(userStaff));
                    }
                    else
                    {
                        await Navigation.PushAsync(new StudentMainPage(user));
                    }
                }
                else
                {
                    await DisplayAlert("Invalid Password", "Username and password combo is not valid", "OK");
                    PasswordField.Text = string.Empty;
                }
            }
            else
            {
                await DisplayAlert("Invalid Email", "Unable to find account with email", "OK");
                PasswordField.Text = string.Empty;
            }
        }

        protected override void OnAppearing()
        {
            EmailField.Text = string.Empty;
            PasswordField.Text = string.Empty;
            base.OnAppearing();
        }
    }
}