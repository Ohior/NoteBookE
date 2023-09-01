using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NoteBook.Model;
using NoteBook.Views;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace NoteBook.ViewModel
{
    public partial class DetailPageViewModel : ObservableObject
    {

        [ObservableProperty]
        ObservableCollection<NoteBookModel> items;

        public async void GetAllNotes()
        {
            Items = new ObservableCollection<Model.NoteBookModel>();
            var notes = await EditPage.noteBookDatabase.GetAllNoteBooksAsync();
            foreach ( var notebook in notes )
            {
                Items.Add( notebook );
                Debug.WriteLine(notebook.ToString());
            }
        }

        [RelayCommand]
        async Task AddNote()
        {
            await Shell.Current.GoToAsync(nameof(EditPage), new Dictionary<string, object>
            {
                {nameof(EditPage), new NoteBookModel()}
            });
        }

        [RelayCommand]
        async Task NoteBookItemClicked(NoteBookModel noteBook)
        {
            Debug.WriteLine(noteBook.ToString());
            await Shell.Current.GoToAsync(nameof(EditPage), new Dictionary<string, object>
            {
                {nameof(EditPage), noteBook} 
            });
        }
        [RelayCommand]
        async Task DeleteNoteBookSwiped(NoteBookModel noteBook)
        {
            Debug.WriteLine(noteBook?.ToString());
            await EditPage.noteBookDatabase.DeleteNoteBookAsync(noteBook!);
            //Items.Clear();
            GetAllNotes();
        }
    }
}
