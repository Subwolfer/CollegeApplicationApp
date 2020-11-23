using System;
using System.Collections.Generic;
using System.Text;

namespace StudentApplicationApp
{
    interface IPerson
    {
        /// <summary>
        /// Logs person into the system
        /// </summary>
        void Log_In();

        /// <summary>
        /// Creates a persons account
        /// </summary>
        void CreateAccount();
    }
}
