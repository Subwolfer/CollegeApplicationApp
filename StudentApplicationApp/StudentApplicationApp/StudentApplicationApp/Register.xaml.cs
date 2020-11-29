using StudentApplicationApp.Persistence;
using System;
using System.Linq;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StudentApplicationApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Register : ContentPage
    {
        // Tracks user as a student.
        Student StudentUser { get; set; }

        public Register(Student user)
        {
            InitializeComponent();
            StudentUser = user;
            CheckForSavedData(user.Email);
        }

        public async void CheckForSavedData(string email)
        {
            var connection = DependencyService.Get<ISQLiteDb>().GetConnection();

            var savedApplication = await connection.QueryAsync<StudentApplication>($"select * from StudentApplication where Email = \"{email}\"");

            if (savedApplication.Any())
            {
                FillFormWithSavedData(savedApplication[0]);
            }
        }

        private void UploadButtonClicked(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// User clicked save button to save teh current state of
        /// their application.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveButtonClicked(object sender, EventArgs e)
        {
            SaveRegistration();
        }

        /// <summary>
        /// Submits the registration
        /// </summary>
        /// <param name="sender">Go back button.</param>
        /// <param name="e">Button clicked event args.</param>
        private async void SubmitRegistration(object sender, EventArgs e)
        {
            StudentApplication completedApplication = GetApplicationData();
            var response = completedApplication.CompleteApplication();
            if (response == StudentApplication.ApplicationResult.Success)
            {
                await DisplayAlert("Application Submitted", "You can log in and check the status of your application at any time", "OK");
                await Navigation.PopAsync();
            }
            else
            {
                switch (response)
                {
                    case StudentApplication.ApplicationResult.MissingField:
                        await DisplayAlert("Missing Fields", "Please check and make sure all fields are filled out", "OK");
                        break;

                    case StudentApplication.ApplicationResult.InvalidFirstName:
                        await DisplayAlert("Invalid Field", "The first name field is invalid, Please check the information entered", "OK");
                        break;

                    case StudentApplication.ApplicationResult.InvalidLastName:
                        await DisplayAlert("Invalid Field", "The last name field is invalid, Please check the information entered", "OK");
                        break;

                    case StudentApplication.ApplicationResult.InvalidStreet:
                        await DisplayAlert("Invalid Field", "The street Address field is invalid, Please check the information entered", "OK");
                        break;

                    case StudentApplication.ApplicationResult.InvalidCity:
                        await DisplayAlert("Invalid Field", "The city field is invalid, Please check the information entered", "OK");
                        break;

                    case StudentApplication.ApplicationResult.InvalidState:
                        await DisplayAlert("Invalid Field", "The state field is invalid, Please check the information entered", "OK");
                        break;

                    case StudentApplication.ApplicationResult.InvalidZip:
                        await DisplayAlert("Invalid Field", "The zip code field is invalid, Please check the information entered", "OK");
                        break;

                    default:
                        await DisplayAlert("Unkonwn", "An unkonwn error has occured when submitting the application", "OK");
                        break;
                }
            }
        }

        /// <summary>
        /// Saves Registration state so it can be loaded from this state if the user naviates away from the ocme and comes
        /// back at a later time.
        /// </summary>
        private void SaveRegistration()
        {
            StudentApplication inProgressApplication = GetApplicationData();
            inProgressApplication.Email = StudentUser.Email;
            inProgressApplication.SaveApplication();
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

        /// <summary>
        /// returns application data.
        /// </summary>
        private StudentApplication GetApplicationData()
        {
            return new StudentApplication{
                Email = StudentUser.Email,
                FirstName = this.FirstName.Text,
                LastName = this.LastName.Text,
                Street = this.Street.Text,
                City = this.City.Text,
                State = this.State.Text,
                Zip = this.Zip.Text,
            };
        }

        /// <summary>
        /// Fills out the application with any previously saved data.
        /// </summary>
        private void FillFormWithSavedData(StudentApplication savedApplication)
        {
            this.FirstName.Text = savedApplication.FirstName;
            this.LastName.Text = savedApplication.LastName;
            this.Street.Text = savedApplication.Street;
            this.City.Text = savedApplication.City;
            this.State.Text = savedApplication.State;
            this.Zip.Text = savedApplication.Zip;
        }
    }
}