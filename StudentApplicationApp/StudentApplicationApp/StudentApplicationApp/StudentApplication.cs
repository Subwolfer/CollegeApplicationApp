using SQLite;
using StudentApplicationApp.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace StudentApplicationApp
{
    class StudentApplication
    {
        public enum ApplicationResult
        { 
            Success = 0,
            MissingField,
            MissingUpload,
            InvalidFirstName,
            InvalidLastName,
            InvalidStreet,
            InvalidCity,
            InvalidState,
            InvalidZip,
        }

        [PrimaryKey, Unique, MaxLength(255)]
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

        public bool submitted { get; set; }

        public bool accepted { get; }

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
        /// <param name="first"></param>
        /// <param name="last"></param>
        /// <param name="street"></param>
        /// <param name="city"></param>
        /// <param name="state"></param>
        /// <param name="zip"></param>
        public StudentApplication(string email, string first, string last, string street, string city, string state, string zip)
        {
            Email = email;
            FirstName = first;
            LastName = last;
            Street = street;
            City = city;
            State = state;
            Zip = zip;
            submitted = false;
        }

        public ApplicationResult CompleteApplication ()
        {
            var result = ValidateFields();
            if (result == ApplicationResult.Success)
            {
                submitted = true;
                SaveApplication();
            }

            return result;
        }

        /// <summary>
        /// Validates that all fields are filled in,
        /// then validates each field individually This is
        /// written this way to be extensible for adding more
        /// validations.
        /// </summary>
        /// <returns></returns>
        public ApplicationResult ValidateFields()
        {
            // Validate No fields are null or empty
            if (string.IsNullOrEmpty(FirstName)
                || (string.IsNullOrEmpty(LastName))
                || (string.IsNullOrEmpty(Street))
                || (string.IsNullOrEmpty(City))
                || (string.IsNullOrEmpty(State))
                || (string.IsNullOrEmpty(Zip)))
            {
                return ApplicationResult.MissingField;
            }

            // Validate FirstName
            if (FirstName.Length < 2 || FirstName.Length > 255 || CheckForInvalidCharacters(FirstName))
            {
                return ApplicationResult.InvalidFirstName;
            }

            // Validate LastName
            if (LastName.Length < 2 || LastName.Length > 255 || CheckForInvalidCharacters(LastName))
            {
                return ApplicationResult.InvalidLastName;
            }

            // validate Street
            if (Street.Length < 2 || Street.Length > 255 || CheckForInvalidCharacters(Street))
            {
                return ApplicationResult.InvalidStreet;
            }

            // Validate City
            if (City.Length < 2 || City.Length > 255 || CheckForInvalidCharacters(City))
            {
                return ApplicationResult.InvalidCity;
            }

            // Validate State
            if (State.Length < 2 || State.Length > 50 || CheckForInvalidCharacters(State))
            {
                return ApplicationResult.InvalidState;
            }

            // Validate Zipcode
            if (Zip.Length < 2 || Zip.Length > 11 || CheckForInvalidCharacters(Zip))
            {
                return ApplicationResult.InvalidZip;
            }

            return ApplicationResult.Success;
        }

        /// <summary>
        /// Checks if there are any invalid characters in the string
        /// </summary>
        /// <param name="stringToCheck"></param>
        /// <returns></returns>
        public bool CheckForInvalidCharacters(string stringToCheck)
        {
            string invalidCharacters = "!@#$%^&*(){}|:\"<>?/.,;][\\`~`+=*";

            foreach (char c in stringToCheck)
            {
                if (invalidCharacters.Contains(c.ToString()))
                {
                    return true;
                }
            }

            return false;
        }

        // Saves application to Database 
        public async void SaveApplication()
        {
            var connection = DependencyService.Get<ISQLiteDb>().GetConnection();

            await connection.InsertOrReplaceAsync(this);            
        }
    }
}
