using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentApplicationApp
{
    public class Student : IPerson
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(255)]
        public string Name { get; set; }

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
        public void CreateAccount()
        {
            throw new NotImplementedException();
        }

        ///<inheritdoc/>
        public void Log_In()
        {
            throw new NotImplementedException();
        }
    }
}
