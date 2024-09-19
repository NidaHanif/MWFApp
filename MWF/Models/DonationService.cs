using MWF.Codes;
using MWF.Models;
using MWF.Pages;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;

public class DonationService
{
    private List<Donation> donations = new List<Donation>();

    public List<Donation> GetDonations()
    {
        SQLiteConnection _Connection = ConnectionClass.GetConnected();
        SQLiteCommand _Command = new SQLiteCommand(_Connection);
        _Command.CommandText = "SELECT * FROM [vew_Donation]";

        SQLiteDataAdapter _Adapter = new(_Command);
        DataSet _Dataset = new DataSet();
        _Adapter.Fill(_Dataset, "Donation");

        List<Donation> donations = new List<Donation>();

        if (_Dataset.Tables.Count > 0)
        {
            DataTable _DataTable = _Dataset.Tables[0];

            foreach (DataRow _Row in _DataTable.Rows)
            {
                Donation _Donation = new Donation()
                {
                    ID = (int)_Row["ID"],
                    Rec_No = (int)_Row["Rec_No"],
                    Rec_Date = (DateTime)_Row["Rec_Date"],
                    Amount = (decimal)_Row["Amount"],
                    DonorName = (string)_Row["Name"]
                };

                donations.Add(_Donation);
            }
        }

        return donations;
    }

    public Donation GetDonationById(int index)
    {
        return donations[index];
    }

    public void UpdateDonation(int index, Donation updatedDonation)
    {
        donations[index] = updatedDonation;
    }
}
