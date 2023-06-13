using System;
using System.Collections.Generic;
using System.ComponentModel;
using films.Models;
using System.Text;

namespace films.ViewModels
{
    public class FilmViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;
        FilmsListViewModel lvm;
        public Film Film { get; private set; }
        public FilmViewModel()
        {
            Film = new Film();
        }
        public FilmsListViewModel ListViewModel
        {
            get { return lvm; }
            set
            {
                if (lvm != value)
                {
                    lvm = value;
                    OnPropertyChanged("ListViewModel");
                }
            }
        }
        public string Title
        {
            get { return Film.Title; }
            set
            {
                if (Film.Title != value)
                {
                    Film.Title = value;
                    OnPropertyChanged("Title");
                }
            }
        }
        public string Genre
        {
            get { return Film.Genre; }
            set
            {
                if (Film.Genre != value)
                {
                    Film.Genre = value;
                    OnPropertyChanged("Genre");
                }
            }
        }

        public string Director
        {
            get { return Film.Director; }
            set
            {
                if (Film.Director != value)
                {
                    Film.Director = value;
                    OnPropertyChanged("Director");
                }
            }
        }
        public bool wasRead
        {
            get { return Film.View; }
            set
            {
                if (Film.View != value)
                {
                    Film.View = value;
                    OnPropertyChanged("wasRead");
                }
            }
        }

        public string Commentary
        {
            get { return Film.Commentary; }
            set
            {
                if (Film.Commentary != value)
                {
                    Film.Commentary = value;
                    OnPropertyChanged("wasRead");
                }
            }
        }

        public bool IsValid
        {
            get
            {
                return ((!string.IsNullOrEmpty(Title.Trim())) ||
                     (!string.IsNullOrEmpty(Genre.Trim())) ||
                     (!string.IsNullOrEmpty(Director.Trim())) ||
                     (!string.IsNullOrEmpty(Commentary.Trim())));

            }
        }

        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
