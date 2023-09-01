using NoteBook.ViewModel;
using NoteBook.Model;

namespace NoteBook.Views;

public partial class EditPage : ContentPage
{
	public static NoteBookDatabase noteBookDatabase = new NoteBookDatabase();

	public EditPage(EditPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}