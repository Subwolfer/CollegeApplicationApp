using StudentApplicationApp.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentApplicationApp
{
    public class Staff : Person
    {
        /// <summary>
        /// 0 arg constructor required for SQLite connection
        /// </summary>
        public Staff()
        {

        }

        /// <summary>
        /// Constructor for setting up a nwe account.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        public Staff(string email, string password) : base (email, password)
        {
            Email = email;
            Password = password;
            isStaff = true;
            OnAdd();
        }

        ///<inheritdoc/>
        public void CreateAccount()
        {

        }

        ///<inheritdoc/>
        public void Log_In()
        {

        }
    }
}
