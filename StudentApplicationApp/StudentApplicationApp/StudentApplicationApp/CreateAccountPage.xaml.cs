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
    public partial class CreateAccount : ContentPage
    {
        public CreateAccount()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Validates information entered and creates account if possilbe
        /// This will also log user into new account created.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateAccountButtonClicked(object sender, EventArgs e)
        {
            if (ValidateCreateAccountFields(EmailField.Text, PasswordField.Text, ConfirmPasswordField.Text))
            {
                TemporaryStudent newStudent = new TemporaryStudent()
                {
                    Email = EmailField.Text,
                };

                this.Navigation.RemovePage(this.Navigation.NavigationStack.Last());
                LogUserIn(newStudent);
            }

            // create account failed
        }

        /// <summary>
        /// Cancels and returns to prior page.
        /// </summary>
        /// <param name="sender">Go back button.</param>
        /// <param name="e">Button clicked event args.</param>
        private async void CancelButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private bool ValidateCreateAccountFields(string email, string password, string confirm)
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

            if (string.IsNullOrEmpty(confirm))
            {
                DisplayAlert("Missing Password Confirmation", "Please confirm your password", "OK");
                return false;
            }

            if (password != confirm)
            {
                DisplayAlert("Passwords do not match", "Please re-enter password and confirm", "OK");
                ClearPasswordFields();
                return false;
            }

            try
            {
                Person newAccount = new Person(email, password);
                return true;
            }
            // TODO figure out why this exception is not being caught.
            catch (SQLite.SQLiteException ex)
            {
                DisplayAlert("Email in use", $"The email address {email} is already in use", "OK");
                ClearPasswordFields();
            }
            catch (Exception ex)
            {
                DisplayAlert("Unkonwn Error", $"An unkonwn error has occured: Details {ex.Message}", "OK");
                ClearPasswordFields();
            }

            return false;
        }

        private async void LogUserIn(TemporaryStudent user)
        {
            await Navigation.PushAsync(new StudentMainPage(user));
        }
        
        private void ClearPasswordFields()
        {
            PasswordField.Text = string.Empty;
            ConfirmPasswordField.Text = string.Empty;
        }
    }
}