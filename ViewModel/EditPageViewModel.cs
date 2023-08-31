using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NoteBook.Views;


namespace NoteBook.ViewModel
{
    public partial class EditPageViewModel : ObservableObject
    {
        [ObservableProperty]
        string title;

        [ObservableProperty]
        string detail;

        [RelayCommand]
        async Task SaveTask()
        {
            if (string.IsNullOrWhiteSpace(Title) || string.IsNullOrWhiteSpace(Detail))
            {
                await Shell.Current.DisplayAlert($"{Title} and {Detail}", "Please enter a name for the todo item.", "OK");
                return;
            }
             await EditPage.noteBookDatabase.SaveNoteBookAsync(new Model.NoteBookModel
            {
                NoteTitle = Title,
                NoteDetail = Detail,
            });
            Title = string.Empty;
            Detail = string.Empty;






            await Shell.Current.GoToAsync("..");
        }
    }
}
