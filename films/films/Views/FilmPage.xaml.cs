using films.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace films.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FilmPage : ContentPage
    {
        public FilmViewModel ViewModel { get; private set; }
        public FilmPage(FilmViewModel vm)
        {
            InitializeComponent();
            ViewModel = vm;
            this.BindingContext = ViewModel;
        }
    }
}