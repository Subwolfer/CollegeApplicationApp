using SQLite;
using StudentApplicationApp.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentApplicationApp
{
    public class Student : Person
    {
        [MaxLength(255)]
        public string FirstName { get; set; }

        [MaxLength(255)]
        public string LastName { get; set; }

        [MaxLength(255)]
        public string Street { get; set; }

        [MaxLength(255)]
        public string City { get; set; }

        [MaxLength(20)]
        public string State { get; set; }

        [MaxLength(10)]
        public string Zip { get; set; }

        /// <summary>
        /// 0 arg constructor required for SQLite connection
        /// </summary>
        public Student()
        {

        }

        /// <summary>
        /// Full constructor for saving data to SQLite
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <param name="first"></param>
        /// <param name="last"></param>
        /// <param name="street"></param>
        /// <param name="city"></param>
        /// <param name="state"></param>
        /// <param name="zip"></param>
        public Student(string email, string password, string first, string last, string street, string city, string state, string zip) : base(email, password)
        {
            FirstName = first;
            LastName = last;
            Street = street;
            City = city;
            State = state;
            Zip = zip;
            isStaff = false;

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
        public void CreateAccount()
        {

        }

        ///<inheritdoc/>
        public void Log_In()
        {

        }
    }
}
