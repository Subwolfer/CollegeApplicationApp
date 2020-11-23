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
    public partial class RequestInformation : ContentPage
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public RequestInformation()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Moves to Request information page
        /// </summary>
        /// <param name="sender">Request info button.</param>
        /// <param name="e">Button clicked event args.</param>
        private void RequestInformationButtonClicked(object sender, EventArgs e)
        {
            if (isEmailValid())
            {
                // TODO Find out if we need to actually email?
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

        /// <summary>
        /// Checks To see if Email is of a valid type
        /// </summary>
        /// <returns>True if email is valid.</returns>
        private bool isEmailValid()
        {
            // TODO Validate Email
            TemporaryStudent tempStudent = new TemporaryStudent();
            tempStudent.RequestInformation();

            return true;
        }
    }
}