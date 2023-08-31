

namespace NoteBook.Model
{
    public static class Constant
    {
        public const string DatabaseFileName = "NoteBookData.db3";
        public const SQLite.SQLiteOpenFlags Flags =
            // open the database foe read and write
            SQLite.SQLiteOpenFlags.ReadWrite |
            // create database if it does not exit
            SQLite.SQLiteOpenFlags.Create |
            // enable multi thread database access
            SQLite.SQLiteOpenFlags.SharedCache;
        public static string DatabasePath =>
            Path.Combine(FileSystem.AppDataDirectory, DatabaseFileName);
    }
}
