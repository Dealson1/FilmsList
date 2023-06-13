using films.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace films.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FilmsListPage : ContentPage
    {
        public FilmsListPage()
        {
            InitializeComponent();
            BindingContext = new FilmsListViewModel()
            {
                Navigation = this.Navigation
            };
        }
    }
}