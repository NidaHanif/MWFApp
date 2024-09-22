using MWF.Codes;
using System.Data;
using System.Data.SQLite;

public class TableClass
{
    public DataTable MyDataTable { get; set; } = new();
    public DataView MyDataView { get; set; } = new();

    public TableClass(string tableName)
    {
        // Assuming you're using SQLite, connect and load the table into the DataTable
        var connection = ConnectionClass.GetConnected();  // Make sure ConnectionClass is defined

        // Load data from the table into MyDataTable
        using (var adapter = new SQLiteDataAdapter($"SELECT * FROM [{tableName}]", connection))
        {
            DataSet DataSet = new();
            adapter.Fill(DataSet);

            if (DataSet.Tables.Count > 0)
            {
                MyDataTable = DataSet.Tables[0];
                MyDataView = MyDataTable.DefaultView;
            }
        }
    }

    public DataRow GetRow(string ID)
    {
        MyDataView.RowFilter = string.Empty;
        if (MyDataView.Count > 0)
        {
            MyDataView.RowFilter = $"ID={ID}";
            if (MyDataView.Count > 0)
            {
                return MyDataView[0].Row;
            }
        }
        return MyDataTable.NewRow();

    }

    public bool Save(DataRow _Row)
    {
        return true;
    }

    public bool Delete(DataRow _Row)
    {

        return true;
    }

}
