using SQLite;
using StudentApplicationApp.Persistence;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StudentApplicationApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PendingApplicationsPage : ContentPage
    {
        private ObservableCollection<StudentApplication> applications = new ObservableCollection<StudentApplication>();
        private SQLiteAsyncConnection connection;

        public PendingApplicationsPage()
        {
            InitializeComponent();
            connection = DependencyService.Get<ISQLiteDb>().GetConnection();
        }

        protected override void OnAppearing()
        {
            connection.Table<StudentApplication>().ToListAsync();
            base.OnAppearing();
        }
    }
}