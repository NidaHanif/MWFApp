using AppliedDB;
using MWF.Models;
using System.Text;

namespace MWF.Pages.Donation
{
    public partial class DonationForm
    {
        public DonationService Model { get; set; }
        public StringBuilder MyMessages { get; set; }

        private void SaveDonation()
        {
            var RowSave = Model.Donation2Row(Model.SelectedDonation);

            AppliedDB.AppUserModel AppUser = GetAppUser();
            AppliedDB.DataSource Source = new(AppUser);

            var _DataRow = Model.Donation2Row(Model.SelectedDonation);
            AppliedDB.CommandClass _Commands = new(_DataRow, Source.MyConnection);
            
            if (_Commands.SaveChanges())
            {
                // Show Message Record has been saved
            }
            else
            {
                // show message record not saved.
            }


           
        }

        
        public void HandleValidSubmit()
        {

            NavManager.NavigateTo("/DonationList");
        }



        private AppUserModel GetAppUser()
        {
            AppUserModel _AppUser = new AppUserModel();
            _AppUser.DataFile = "Recieptt.db";
            _AppUser.RootFolder = "wwwroot";
            _AppUser.UsersFolder = "Database";
            _AppUser.LanguageFolder = "Database";
            _AppUser.SessionFolder = "Database";
            _AppUser.SystemFolder = "Database";
            _AppUser.MessageFolder = "Database";
            _AppUser.DataPath= "Database";
            _AppUser.ReportFolder= "Reports";
            _AppUser.PDFFolder= "OutputFiles";
            _AppUser.ClientFolder= "Database";


            return _AppUser;
        }

        private void Submit()
        {
            var a = 1;
        }

        private void Back()
        {
            NavManager.NavigateTo("/DonationList");
        }
    }
}
