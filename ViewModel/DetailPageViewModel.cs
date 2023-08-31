using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NoteBook.Views;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace NoteBook.ViewModel
{
    public partial class DetailPageViewModel : ObservableObject
    {

        [ObservableProperty]
        ObservableCollection<Model.NoteBookModel> items;

        public DetailPageViewModel()
        {
            Items = new ObservableCollection<Model.NoteBookModel>();
            GetAllNotes();
        }

        private async void GetAllNotes()
        {
            var notes = await EditPage.noteBookDatabase.GetAllNoteBooksAsync();
            foreach ( var notebook in notes )
            {
                Items.Add( notebook );
                Debug.WriteLine(notebook.ToString());
            }
        }

        [RelayCommand]
        async Task IncreaseCounter()
        {
            await Shell.Current.GoToAsync(nameof(EditPage)); //Counter++;
        }
    }
}
