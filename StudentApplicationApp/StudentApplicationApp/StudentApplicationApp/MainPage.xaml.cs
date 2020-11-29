using StudentApplicationApp.Persistence;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace StudentApplicationApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            var connection = DependencyService.Get<ISQLiteDb>().GetConnection();

            connection.CreateTableAsync<Person>();
            connection.CreateTableAsync<StudentApplication>();

            // The following code is to drop tables so they can be
            // recreated in case of changes. 
            // connection.DropTableAsync<Person>();
            // connection.DropTableAsync<StudentApplication>();

            // This line is for testing uses only. It will create a staff log in
            // with the email "staff@school.com"  and password of "password"
            CreateStaffLogIn();

            base.OnAppearing();
        }

        private async void CreateStaffLogIn()
        {
            string staffEmail = "staff@school.com";
            string staffPass = "password";

            var connection = DependencyService.Get<ISQLiteDb>().GetConnection();

            // Make sure account doesn't exist before you create it.
            var personsCollection = await connection.QueryAsync<Person>($"select * from Person where Email = \'{staffEmail}\'");
            if (!personsCollection.Any())
            {
                Person newStaff = new Person(staffEmail, staffPass);
                newStaff.SetPersonAsStaff();
                newStaff.OnAdd();
            }
        }

        private async void RequestInfoButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RequestInformation());
        }

        private async void LogInButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LogInPage());
        }
    }
}
