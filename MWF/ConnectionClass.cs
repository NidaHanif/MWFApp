using System.Data.SQLite;
using System.Data;

namespace MWF.Codes;
public class ConnectionClass
{
    public static SQLiteConnection GetConnected()
    {
        var FileName = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Database", "Recieptt.db");
        var ConnectionString = $"Data Source={FileName}";
        var connection = new SQLiteConnection(ConnectionString);
        connection.Open();
        return connection;
    }
}
