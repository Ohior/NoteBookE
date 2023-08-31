using SQLite;

namespace NoteBook.Model
{
    public class NoteBookDatabase
    {
       private  SQLiteAsyncConnection Database;

        public NoteBookDatabase()
        {
        }

         public async Task Init()
        {
            if (Database != null) return;
            Database = new SQLiteAsyncConnection(Constant.DatabasePath, Constant.Flags);
            var result = await Database.CreateTableAsync<NoteBookModel>();
        }

        public async Task<List<NoteBookModel>> GetAllNoteBooksAsync()
        {
            await Init();
            return await Database.Table<NoteBookModel>().ToListAsync();
        }

        public async Task<NoteBookModel> GetNoteBookAsync(NoteBookModel noteBook)
        {
            await Init();
            return await Database.Table<NoteBookModel>().Where(i => i.NoteId == noteBook.NoteId).FirstOrDefaultAsync();
        }

        public async Task<int> DeleteNoteBookAsync(NoteBookModel noteBook)
        {
            await Init();
            return await Database.DeleteAsync<NoteBookModel>(noteBook);    
        }

        public async Task<int> SaveNoteBookAsync(NoteBookModel noteBook)
        {
            await Init();
            if (noteBook.NoteId != 0)
            {
                return await Database.UpdateAsync(noteBook);
            }
            else
            {
                return await Database.InsertAsync(noteBook);
            }
        }
    }
}
