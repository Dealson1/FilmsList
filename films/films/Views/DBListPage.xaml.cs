using films.Models;
using films.ViewModels;
using System;
using System.Linq;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace films.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DBListPage : ContentPage
    {
        public DBListPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            var viewModel = new FilmsListViewModel();
            viewModel.TotalFilmsCount = App.DataBase.GetItems().Count();
            viewModel.WatchFilmsCount = App.DataBase.GetItems().Count(b => b.View);
            viewModel.UnwatchFilmsCount = viewModel.TotalFilmsCount - viewModel.WatchFilmsCount;

            BindingContext = viewModel;
            filmsList.ItemsSource = App.DataBase.GetItems();

            var sortedList = App.DataBase.GetItems().OrderBy(b => b.View).ToList();
            filmsList.ItemsSource = sortedList;

            base.OnAppearing();
        }

        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Film selectedFilm = (Film)e.SelectedItem;
            DBFilmPage filmPage = new DBFilmPage();
            filmPage.BindingContext = selectedFilm;
            await Navigation.PushAsync(filmPage);
        }

        private async void CreateFilm(object sender, EventArgs e)
        {
            Film film = new Film();
            DBFilmPage filmPage = new DBFilmPage();
            filmPage.BindingContext = film;
            await Navigation.PushAsync(filmPage);
        }

        private void OnBindingContextChanged(object sender, EventArgs e)
        {
            var cell = sender as ViewCell;
            var film = cell?.BindingContext as Film;

            if (film != null && film.View)
                cell.View.BackgroundColor = Color.Green;
            else
                cell.View.BackgroundColor = Color.Red;

            cell.ForceUpdateSize();
        }
    }
}