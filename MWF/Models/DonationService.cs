using System.Data;
using System.Text;
using System.Runtime.CompilerServices;

namespace MWF.Models
{
    public class DonationService
    {
        public List<Donation> DonationList = new List<Donation>();
        public Donation SelectedDonation { get; set; } = new();
        public DataTable DonationTable { get; set; } = new();
        public StringBuilder MyMessages { get; set; } = new();

        public DonationService()
        {
            DonationList = GetDonations();
            if (DonationList.Count > 0)
            {
                SelectedDonation = DonationList.First();
            }
            else
            {
                SelectedDonation = NewDonation();
            }

        }

        #region Get Record from DataTable to Donation List
        public List<Donation> GetDonations()
        {
            List<Donation> _Donations = new List<Donation>();

            try
            {
                TableClass _TableClass = new("vew_Donation");

                foreach (DataRow _Row in _TableClass.MyDataTable.Rows)
                {
                    _Donations.Add(Row2Donation(_Row));
                }
            }
            catch (Exception ex)
            {
                MyMessages.AppendLine(ex.Message);
                MyMessages.Append($" - Error found in GetDonation() {LogCallerInfo()}"  );
            }

            return _Donations;
        }
        #endregion

        public string LogCallerInfo([CallerMemberName] string memberName = "")
        {
            return $"Called from: {memberName}";
        }

        #region New Donation
        public Donation NewDonation()
        {
            return new Donation();
        }
        #endregion

        #region Select, Update, Delete Donation from List. not from DataTable.
        public Donation SelectDonation(int ID)
        {
            Donation? _Donation = DonationList.FirstOrDefault(a => a.ID == ID);
            SelectedDonation = _Donation ?? NewDonation();
            return _Donation ?? NewDonation();
        }

        public void UpdateDonation(int ID)
        {
            if (ID > 0)
            {
                SelectedDonation = DonationList.FirstOrDefault(a => a.ID == ID) ?? NewDonation();
            }
        }
        public void DeleteDonation(int ID)
        {
            if (ID > 0)
            {
                SelectedDonation = DonationList.FirstOrDefault(a => a.ID == ID) ?? NewDonation();
                DonationList.Remove(SelectedDonation);
                SelectedDonation = DonationList.First() ?? NewDonation();
            }
        }
        public void InsertDonation(Donation _Donation)
        {
            DonationList.Add(_Donation);
        }
        #endregion

        #region Row to Donation and Donation to Row
        public Donation Row2Donation(DataRow _Row)
        {
            _Row = AppliedDB.Functions.RemoveNull(_Row);

            Donation _Donation = new Donation()
            {

                ID = (int)_Row["ID"],
                Rec_No = (int)_Row["Rec_No"],
                Rec_Date = (DateTime)_Row["Rec_Date"],
                DonorID = (int)_Row["DonorID"],
                Reference = (string)_Row["Reference"],
                DonationType = (int)_Row["DonationType"],
                PaymentMode = (int)_Row["PaymentMode"],
                ChequeNo = (string)_Row["ChequeNo"],
                Currency = (int)_Row["Currency"],
                Amount = (decimal)_Row["Amount"],
                Remarks = (string)_Row["Remarks"],
                Email = (string)_Row["Email"],
                Phone = (string)_Row["Phone"],
                Status = (string)_Row["Status"],
            };
            return _Donation;
        }

        public DataRow Donation2Row(Donation _Donation)
        {
            var _Row = DonationTable.NewRow();
            _Row["ID"] = _Donation.ID;
            _Row["Rec_No"] = _Donation.Rec_No;
            _Row["Rec_Date"] = _Donation.Rec_Date;
            _Row["DonorID"] = _Donation.DonorID;
            _Row["Reference"] = _Donation.Reference;
            _Row["DonationType"] = _Donation.DonationType;
            _Row["PaymentMode"] = _Donation.PaymentMode;
            _Row["ChequeNo"] = _Donation.ChequeNo;
            _Row["Currency"] = _Donation.Currency;
            _Row["Amount"] = _Donation.Amount;
            _Row["Remarks"] = _Donation.Remarks;
            _Row["Email"] = _Donation.Email;
            _Row["Phone"] = _Donation.Phone;
            _Row["Status"] = _Donation.Status;
            return _Row;
        }
        #endregion

        #region Save and Delete Donation from DataTable
        public bool Save(int ID)
        {

            return true;
        }

        public bool Delete(int ID)
        {
            return true;
        }
        #endregion

        #region Print
        public void PrintDonation(int ID)
        {
            //  Make code here to print the donation receipt
        }
        #endregion

    }

    public class Donation
    {
        public int ID { get; set; }
        public int Rec_No { get; set; }
        public DateTime Rec_Date { get; set; } = DateTime.Now;
        public int DonorID { get; set; }
        public string Reference { get; set; } = string.Empty;
        public int DonationType { get; set; }
        public int PaymentMode { get; set; }
        public string ChequeNo { get; set; } = string.Empty;
        public int Currency { get; set; }
        public decimal Amount { get; set; }
        public string Remarks { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Status { get; set; } = "Submitted";

        public virtual string TitleDonor { get; set; } = string.Empty;
        public virtual string TitleDonationType { get; set; } = string.Empty;
        public virtual string TitlePaymentMode { get; set; } = string.Empty;
        public virtual string TitleCurrency { get; set; } = string.Empty;

    }
}
