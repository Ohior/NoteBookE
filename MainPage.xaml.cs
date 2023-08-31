using NoteBook.ViewModel;

namespace NoteBook
{
    public partial class MainPage : ContentPage
    {
        public MainPage(DetailPageViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}