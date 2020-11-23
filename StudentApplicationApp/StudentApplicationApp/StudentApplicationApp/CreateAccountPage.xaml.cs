﻿using System;
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
                    email = EmailField.Text,
                };

            }
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

            PostAccountToDatabase(email, password);

            return true;
        }
        
        private void ClearPasswordFields()
        {
            PasswordField.Text = string.Empty;
            ConfirmPasswordField.Text = string.Empty;
        }

        private bool PostAccountToDatabase(string Email, string password)
        {
            // TODO Validate Email isn't already saved to database. 
            // TODO Save account to database
            return true;
        }
    }
}