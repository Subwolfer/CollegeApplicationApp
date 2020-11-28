using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentApplicationApp
{
    class StudentApplication
    {
        [PrimaryKey]
        public string Email { get; set; }

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
        public StudentApplication()
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
        public StudentApplication(string email, string password, string first, string last, string street, string city, string state, string zip)
        {
            Email = email;
            FirstName = first;
            LastName = last;
            Street = street;
            City = city;
            State = state;
            Zip = zip;
        }

    }
}
