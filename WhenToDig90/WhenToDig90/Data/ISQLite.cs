
using SQLite.Net.Async;

namespace WhenToDig90.Data
{
    public interface ISQLite
    {
        SQLiteAsyncConnection GetAsyncConnection();
    }
}

