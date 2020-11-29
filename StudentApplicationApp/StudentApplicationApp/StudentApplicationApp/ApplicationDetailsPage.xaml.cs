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
    public partial class ApplicationDetailsPage : ContentPage
    {
        StudentApplication app;

        /// <summary>
        /// Constructor for the page that takes in a student application
        /// </summary>
        /// <param name="studentApp"></param>
        public ApplicationDetailsPage(StudentApplication studentApp)
        {
            InitializeComponent();

            app = studentApp;
            fillInData();
        }

        /// <summary>
        /// Fills in form data with the application data.
        /// </summary>
        /// <param name="app"></param>
        public void fillInData()
        {
            this.StudentName.Text = app.FirstName + " " + app.LastName;
            this.Email.Text = app.Email;
            this.AddressLine1.Text = app.Street;
            this.AddressLien2.Text = app.City + " " + app.State + " " + app.Zip;
        }

        /// <summary>
        /// Sets application to be approved
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ApproveButtonClicked(object sender, EventArgs e)
        {
            app.accepted = 1;
            UpdateDatabaseAndExitPage();
        }

        /// <summary>
        /// Sets application to be denied
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DenyButtonClicked(object sender, EventArgs e)
        {
            app.accepted = 0;
            UpdateDatabaseAndExitPage();
        }

        /// <summary>
        /// Updates the database with approveal or deniel and returns to 
        /// the pending application page.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void UpdateDatabaseAndExitPage()
        {
            app.applicationFinalized = 1;
            app.SaveApplication();

            await Navigation.PopAsync();
        }
    }
}