using System;
using System.Collections.Generic;
using System.Linq;
using MvvmCross.Platform;
using Notes.Database.Interfaces;
using Notes.Database.Schema;
using SQLite.Net;

namespace Notes.Database
{
    public class DataRepository
    {
        private readonly ISQLite _database = Mvx.Resolve<ISQLite>();
        private readonly Lazy<SQLiteConnection> _conn;
        private readonly object locker = new object();

        public DataRepository()
        {
            _conn = new Lazy<SQLiteConnection>(() => _database.GetConnection());
        }

        public bool CreateDatabaseIfNotExist()
        {
            if (!_database.CheckDatabaseExistance())
            {
                CreateDatabaseImpl();
                return true;
            }
            return false;
        }

        private void CreateDatabaseImpl()
        {
            _conn.Value.CreateTable<LocalNote>();
        }

        public Boolean CheckDatabaseExistance()
        {
            return _database.CheckDatabaseExistance();
        }

        public void AddNote(LocalNote note)
        {
            lock (locker)
            {
                _conn.Value.Insert(note);
            }
        }

        public List<LocalNote> GetNotes()
        {
            lock (locker)
            {
                return _conn.Value.Table<LocalNote>().ToList();
            }
        }

        public LocalNote GetNote(long id)
        {
            lock (locker)
            {
                return _conn.Value.Table<LocalNote>().FirstOrDefault(note => note.Id == id);
            }
        }

        public void UpdateNote(LocalNote note)
        {
            lock (locker)
            {
                _conn.Value.Update(note);
            }
        }

        public void RemoveNote(long id)
        {
            lock (locker)
            {
                _conn.Value.Execute("DELETE FROM Notes WHERE Id=" + id + "");
            }
        }
    }
}
