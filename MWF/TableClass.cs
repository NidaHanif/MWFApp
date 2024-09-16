using MWF.Codes;
using System.Data;
using System.Data.SQLite;

public class TableClass
{
    public DataTable MyDataTable { get; set; }
    public DataView MyDataView { get; set; }

    public TableClass(string tableName)
    {
        // Assuming you're using SQLite, connect and load the table into the DataTable
        var connection = ConnectionClass.GetConnected();  // Make sure ConnectionClass is defined

        // Load data from the table into MyDataTable
        using (var adapter = new SQLiteDataAdapter($"SELECT * FROM [{tableName}]", connection))
        {
            MyDataTable = new DataTable();
            adapter.Fill(MyDataTable);
        }

        MyDataView = new DataView(MyDataTable);
    }
}
