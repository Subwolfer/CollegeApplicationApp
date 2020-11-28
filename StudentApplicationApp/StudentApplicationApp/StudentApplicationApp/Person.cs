using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace StudentApplicationApp.Persistence
{
    public class Person : IPerson
    {
        [PrimaryKey, Unique, MaxLength(255)]
        public string Email { get; set; }

        [MaxLength(255)]
        public string Password { get; set; }

        public bool isStaff { get; set; }

        /// <summary>
        /// 0 arg constructor required for SQLite connection
        /// </summary>
        public Person()
        {

        }

        /// <summary>
        /// Constructor for setting up a nwe account.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        public Person(string email, string password)
        {
            Email = email;
            Password = password;
            isStaff = false; // false by default

            OnAdd();
        }

        public void SetPersonAsStaff()
        {
            isStaff = true;
            var connection = DependencyService.Get<ISQLiteDb>().GetConnection();
            connection.UpdateAsync(this);
        }

        public async void OnAdd()
        {
            var connection = DependencyService.Get<ISQLiteDb>().GetConnection();

            await connection.InsertAsync(this);
        }

        /// <summary>
        /// Virtual funciton. Not implemented here.
        /// </summary>
        public virtual void CreateAccount()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Virtual funciton. Not implemented here.
        /// </summary>
        public virtual void Log_In()
        {
            throw new NotImplementedException();
        }
    }
}
