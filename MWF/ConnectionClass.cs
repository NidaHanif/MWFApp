using System.Data.SQLite;
using System.Data;

namespace MWF.Codes;
public class ConnectionClass
{
    public static SQLiteConnection GetConnected(string _FileName)
    {
        var FileName = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Database", _FileName);
        var ConnectionString = $"Data Source={FileName}";
        var connection = new SQLiteConnection(ConnectionString);
        connection.Open();
        return connection;
    }
}
