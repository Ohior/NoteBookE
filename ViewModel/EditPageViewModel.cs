using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NoteBook.Model;
using NoteBook.Views;


namespace NoteBook.ViewModel
{
    [QueryProperty("Note", nameof(EditPage))]
    public partial class EditPageViewModel : ObservableObject
    {
        //[ObservableProperty]
        //string title;

        //[ObservableProperty]
        //string detail;

        [ObservableProperty]
        NoteBookModel note;

        [RelayCommand]
        async Task SaveTask()
        {
            if (string.IsNullOrWhiteSpace(Note.NoteTitle) || string.IsNullOrWhiteSpace(Note.NoteDetail))
            {
                await Shell.Current.DisplayAlert($"{Note.NoteTitle} and {Note.NoteTitle}", "Please enter a name for the todo item.", "OK");
                return;
            }
             await EditPage.noteBookDatabase.SaveNoteBookAsync(new Model.NoteBookModel
            {
                 NoteId = Note.NoteId,
                NoteTitle = Note.NoteTitle,
                NoteDetail = Note.NoteDetail,
            });
            //Title = string.Empty;
            //Detail = string.Empty;
            await Shell.Current.GoToAsync("..");
        }
    }
}
