using SQLite;
using StudentApplicationApp.Persistence;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StudentApplicationApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PendingApplicationsPage : ContentPage
    {
        private ObservableCollection<PendingApplications> pendingApplications = new ObservableCollection<PendingApplications>();
        private SQLiteAsyncConnection connection;

        public PendingApplicationsPage()
        {
            InitializeComponent();
            connection = DependencyService.Get<ISQLiteDb>().GetConnection();
        }

        protected async override void OnAppearing()
        {
            var appCollection = await connection.QueryAsync<StudentApplication>("select * from StudentApplication");

            foreach (StudentApplication app in appCollection)
            {
                // check if submitted and not finalized
                if (app.applicationFinalized == 0)
                {
                    PendingApplications pendingApp = new PendingApplications();
                    pendingApp.studentName = app.FirstName + " " + app.LastName;
                    pendingApplications.Add(pendingApp);
                }
            }

            if (pendingApplications.Any())
            {
                this.Header.Text = "Pending Applications";
            }
            else
            {
                this.Header.Text = "No Pending Applications";
            }

            base.OnAppearing();
        }
    }

    public class PendingApplications
    {
        public string studentName { get; set; }
        public StudentApplication studentApp { get; set; }
    }
}