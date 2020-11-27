using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentApplicationApp.Persistence
{
    public interface ISQLiteDb
    {
        SQLiteAsyncConnection GetConnection();
    }
}
