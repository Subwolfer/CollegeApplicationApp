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

            base.OnAppearing();
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
