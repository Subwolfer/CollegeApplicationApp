using SQLite;
using StudentApplicationApp.Persistence;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StudentApplicationApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PendingApplicationsPage : ContentPage, INotifyPropertyChanged
    {
        // list of pending applications
        private ObservableCollection<PendingApplications> pendingApplications { get; set; } = new ObservableCollection<PendingApplications>();

        // stored the connection as we will use it alot in this file
        private SQLiteAsyncConnection connection;

        /// <summary>
        /// Constructor for page.
        /// </summary>
        public PendingApplicationsPage()
        {
            InitializeComponent();
            connection = DependencyService.Get<ISQLiteDb>().GetConnection();
        }

        /// <summary>
        /// Override to load when screen is drawn and set to appear.
        /// </summary>
        protected async override void OnAppearing()
        {
            var appCollection = await connection.QueryAsync<StudentApplication>("select * from StudentApplication");

            foreach (StudentApplication app in appCollection)
            {
                // check if submitted and not finalized
                if (app.submitted > 0 && app.applicationFinalized <= 0)
                {
                    PendingApplications pendingApp = new PendingApplications();
                    pendingApp.studentName = app.FirstName + " " + app.LastName;
                    pendingApp.studentApp = app;
                    pendingApplications.Add(pendingApp);
                }
            }

            // Heading is set if there are any pending applications present. 
            if (pendingApplications.Any())
            {
                this.Header.Text = "Pending Applications";
                appliationsListView.ItemsSource = pendingApplications;
            }
            else
            {
                this.Header.Text = "No Pending Applications";
            }

            base.OnAppearing();
        }
    }

    /// <summary>
    /// Pending application class used for populating list of pending applications.
    /// </summary>
    public class PendingApplications
    {
        public string studentName { get; set; }

        public StudentApplication studentApp { get; set; }
    }
}