using System;
using System.IO;
using Notes.Database.Interfaces;
using SQLite.Net;
using SQLite.Net.Platform.XamarinAndroid;

namespace Notes.Services
{
    public class SQLite : ISQLite
    {
        private const string DATABASE_NAME = "Nodes.db";
        private readonly string _path;

        public SQLite()
        {
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            _path = Path.Combine(documentsPath, DATABASE_NAME);
        }

        public bool CheckDatabaseExistance()
        {
            return File.Exists(_path);
        }

        public SQLiteConnection GetConnection()
        {
            var conn = new SQLiteConnection(new SQLitePlatformAndroid(), _path);
            return conn;
        }
    }
}