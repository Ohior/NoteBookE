using SQLite;

namespace NoteBook.Model
{
    public class NoteBookModel
    {
        [PrimaryKey, AutoIncrement]
        public int NoteId { get; set; }
        public string NoteTitle { get; set; }
        public string NoteDetail { get; set; }

        public override string ToString()
        {
            return $"NoteId = {NoteId}, NoteTitle = {NoteTitle}, NoteDetail = {NoteDetail}";
        }

    }
}
