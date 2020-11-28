using SQLite;
using StudentApplicationApp.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentApplicationApp
{
    public class Student : Person
    {
        /// <summary>
        /// 0 arg constructor required for SQLite connection
        /// </summary>
        public Student()
        {

        }

        /// <summary>
        /// Request informationt to be sent about a specific class
        /// </summary>
        public void RequestInformation()
        {

        }

        /// <summary>
        /// Checks status of the application
        /// </summary>
        public void CheckStatus()
        {

        }

        ///<inheritdoc/>
        public override void CreateAccount()
        {

        }

        ///<inheritdoc/>
        public override void Log_In()
        {

        }
    }
}
