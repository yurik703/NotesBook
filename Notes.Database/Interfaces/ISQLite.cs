using System;
using SQLite.Net;

namespace Notes.Database.Interfaces
{
    public interface ISQLite
    {
        Boolean CheckDatabaseExistance();
        SQLiteConnection GetConnection();
    }
}
