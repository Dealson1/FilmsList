using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using films.Models;

namespace films.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DBFilmPage : ContentPage
    {
        public DBFilmPage()
        {
            InitializeComponent();
        }
        private void SaveFilm(object sender, EventArgs e)
        {
            var film = (Film)BindingContext;
            if (!String.IsNullOrEmpty(film.Title))
            {
                App.DataBase.SaveItem(film);
            }
            this.Navigation.PopAsync();
        }
        private void DeleteFilm(object sender, EventArgs e)
        {
            var film = (Film)BindingContext;
            App.DataBase.DeleteItem(film.Id);
            this.Navigation.PopAsync();
        }
        private void Cancel(object sender, EventArgs e)
        {
            this.Navigation.PopAsync();
        }
    }
}