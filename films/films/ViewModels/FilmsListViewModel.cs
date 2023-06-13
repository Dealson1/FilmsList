using films.Views;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;


namespace films.ViewModels
{
    public class FilmsListViewModel
    {
        private int totalFilmsCount;
        public int TotalFilmsCount
        {
            get { return totalFilmsCount; }
            set
            {
                if (totalFilmsCount != value)
                {
                    totalFilmsCount = value;
                    OnPropertyChanged("TotalFilmsCount");
                }
            }
        }

        private int watchFilmsCount;
        public int WatchFilmsCount
        {
            get { return watchFilmsCount; }
            set
            {
                if (watchFilmsCount != value)
                {
                    watchFilmsCount = value;
                    OnPropertyChanged("WatchFilmsCount");
                }
            }
        }

        private int unwatchFilmsCount;
        public int UnwatchFilmsCount
        {
            get { return unwatchFilmsCount; }
            set
            {
                if (unwatchFilmsCount != value)
                {
                    unwatchFilmsCount = value;
                    OnPropertyChanged("UnwatchFilmsCount");
                }
            }
        }
        private void UpdateFilmsCounts()
        {
            TotalFilmsCount = App.DataBase.GetItems().Count();
            WatchFilmsCount = App.DataBase.GetItems().Count(b => b.View == true);
            UnwatchFilmsCount = TotalFilmsCount - WatchFilmsCount;
        }

        public ObservableCollection<FilmViewModel> Films { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand CreateFilmCommand { protected set; get; }
        public ICommand DeleteFilmCommand { protected set; get; }
        public ICommand SaveFilmCommand { protected set; get; }
        public ICommand BackCommand { protected set; get; }
        FilmViewModel selectedFilm;
        public INavigation Navigation { get; set; }
        public FilmsListViewModel()
        {
            Films = new ObservableCollection<FilmViewModel>();
            CreateFilmCommand = new Command(CreateFilm);
            DeleteFilmCommand = new Command(DeleteFilm);
            SaveFilmCommand = new Command(SaveFilm);
            BackCommand = new Command(Back);
        }
        public FilmViewModel SelectedFilm
        {
            get { return selectedFilm; }
            set
            {
                if (selectedFilm != value)
                {
                    FilmViewModel tempFilm = value;
                    selectedFilm = null;
                    OnPropertyChanged("SelectedFilm");
                    Navigation.PushAsync(new FilmPage(tempFilm));
                }
            }
        }

        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
        private void CreateFilm()
        {
            Navigation.PushAsync(new FilmPage(new FilmViewModel() { ListViewModel = this }));
        }
        private void Back()
        {
            Navigation.PopAsync();
        }
        private void SaveFilm(object filmObject)
        {
            FilmViewModel film = filmObject as FilmViewModel;
            if (film != null && film.IsValid && !Films.Contains(film))
            {
                Films.Add(film);
            }
            Back();
        }
        private void DeleteFilm(object filmObject)
        {
            FilmViewModel film = filmObject as FilmViewModel;
            if (film != null)
            {
                Films.Remove(film);
            }
            Back();
        }
    }
}
