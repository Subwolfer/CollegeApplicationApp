using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StudentApplicationApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StaffMainPage : ContentPage
    {
        public StaffMainPage(Staff user)
        {
            InitializeComponent();
        }

        /// <summary>
        /// CLogs out and returns to log in screen
        /// </summary>
        /// <param name="sender">Go back button.</param>
        /// <param name="e">Button clicked event args.</param>
        private async void LogOutButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        /// <summary>
        /// CLogs out and returns to log in screen
        /// </summary>
        /// <param name="sender">Go back button.</param>
        /// <param name="e">Button clicked event args.</param>
        private async void ViewApplicationsButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PendingApplicationsPage());
        }
    }
}