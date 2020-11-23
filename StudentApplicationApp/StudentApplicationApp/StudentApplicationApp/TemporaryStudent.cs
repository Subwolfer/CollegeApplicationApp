using System;
using System.Collections.Generic;
using System.Text;

namespace StudentApplicationApp
{
    class TemporaryStudent : Student
    {
        public string email;

        /// <summary>
        /// Starts the application process
        /// </summary>
        public void Apply()
        {

        }

        /// <summary>
        /// Uploads documents into the application
        /// </summary>
        public void UploadDocuments()
        {

        }

        /// <summary>
        /// Subits the application to be reviewed by staff
        /// </summary>
        public void SubmitApplication()
        {
            ConvertToStudent();
        }

        /// <summary>
        /// Converts temporary student to actual student upon submission of applciation
        /// </summary>
        private void ConvertToStudent()
        {

        }
    }
}
