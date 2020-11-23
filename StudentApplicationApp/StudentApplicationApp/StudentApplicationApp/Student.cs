using System;
using System.Collections.Generic;
using System.Text;

namespace StudentApplicationApp
{
    class Student : IPerson
    {
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
