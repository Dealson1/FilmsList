using films.Models;
using films.Views;
using System;
using System.IO;
using Xamarin.Forms;

namespace films
{
    public partial class App : Application
    {
        public const string DATABASE_NAME = "film.db";
        public static FilmRepository database;
        public static FilmRepository DataBase
        {
            get
            {
                if (database == null)
                {
                    database = new FilmRepository
                        (Path.Combine(
                            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DATABASE_NAME));

                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new DBListPage());
        }
    }
}
