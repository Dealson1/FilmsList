using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace films.Models
{
    public class FilmRepository
    {
        SQLiteConnection database;
        public FilmRepository(string databasePath)
        {
            database = new SQLiteConnection(databasePath);
            database.CreateTable<Film>();
        }
        public IEnumerable<Film> GetItems()
        {
            return database.Table<Film>().ToList();
        }
        public Film GetItem(int id)
        {
            return database.Get<Film>(id);
        }
        public int DeleteItem(int id)
        {
            return database.Delete<Film>(id);
        }
        public int SaveItem(Film item)
        {
            if (item.Id != 0)
            {
                database.Update(item);
                return item.Id;
            }
            else
            {
                return database.Insert(item);
            }
        }
    }
}
