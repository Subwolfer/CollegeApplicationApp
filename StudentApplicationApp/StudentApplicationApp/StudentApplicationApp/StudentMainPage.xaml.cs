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
    public partial class StudentMainPage : ContentPage
    {        
        // Tracks user as a student.
        Student StudentUser { get; set; }

        /// <summary>
        /// constructor for student login.
        /// </summary>
        /// <param name="user"></param>
        public StudentMainPage(Student user)
        {
            StudentUser = user;
            InitializeComponent();
        }

        /// <summary>
        /// Load Request information screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void RequestInformationButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RequestInformation());
        }

        /// <summary>
        /// Move to apply screen for student.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void ApplyButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Register(StudentUser));
        }

        /// <summary>
        /// CLogs out and returns to log in screen
        /// </summary>
        /// <param name="sender">Go back button.</param>
        /// <param name="e">Button clicked event args.</param>
        private async void LogOutButtonClicked(object sender, EventArgs e)
        {
            StudentUser = null;
            await Navigation.PopAsync();
        }

        /// <summary>
        /// CLogs out and returns to log in screen
        /// </summary>
        /// <param name="sender">Go back button.</param>
        /// <param name="e">Button clicked event args.</param>
        private async void ApplicationStatusButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new StudentApplicationStatusPage(StudentUser));
        }
    }
}