using StudentApplicationApp.Persistence;
using System.Linq;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StudentApplicationApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StudentApplicationStatusPage : ContentPage
    {

        public StudentApplicationStatusPage(Student user)
        {
            InitializeComponent();
            LoadApplication(user);
        }

        private async void LoadApplication(Student user)
        {
            string headerString = "No Applications Found";
            var connection = DependencyService.Get<ISQLiteDb>().GetConnection();

            var savedApplication = await connection.QueryAsync<StudentApplication>($"select * from StudentApplication where Email = \"{user.Email}\"");

            if (savedApplication.Any())
            {
                StudentApplication app = savedApplication[0];
                if (app.submitted)
                {
                    headerString = "Submitted Application";
                    this.StudentName.Text = app.FirstName + " " + app.LastName;
                    this.Email.Text = app.Email;
                    this.AddressLine1.Text = app.Street;
                    this.AddressLien2.Text = app.City + " " + app.State + " " + app.Zip;

                    if (app.applicationFinalized)
                    {
                        if (app.accepted)
                        {
                            this.Status.Text = "Status = Accepted";
                        }
                        else
                        {
                            this.Status.Text = "Status = Denied";
                        }
                    }
                    else
                    {
                        this.Status.Text = "Status = Pending";
                    }
                }
            }

            this.Header.Text = headerString;
        }
    }
}