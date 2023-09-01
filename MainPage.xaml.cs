using NoteBook.ViewModel;

namespace NoteBook
{
    public partial class MainPage : ContentPage
    {
        private DetailPageViewModel _viewModel;
        public MainPage(DetailPageViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            BindingContext = viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.GetAllNotes();
        }
    }
}