﻿using AppliedDB;
using MWF.Models;
using System.Text;

namespace MWF.Pages.Donation
{
    public partial class DonationForm
    {
        public DonationService Model { get; set; }
        public StringBuilder MyMessages { get; set; }
        public string ModolMessage { get; set; }


        private void Submit()
        {
            var a = 1;
        }

        private void SaveDonation()
        {
            Model.MyMessages.Clear();

            var RowSave = Model.Donation2Row(Model.SelectedDonation);

            AppliedDB.AppUserModel AppUser = GetAppUser();
            AppliedDB.DataSource Source = new(AppUser);

            var _DataRow = Model.Donation2Row(Model.SelectedDonation);
            AppliedDB.CommandClass _Commands = new(_DataRow, Source.MyConnection);


            if (_Commands.SaveChanges())
            {
                ModolMessage = "Donation receipt has been saved.";
            }
            else
            {
                ModolMessage = "Donation receipt NOT saved.";
            }



        }

        private void Back()
        {
            NavManager.NavigateTo("/DonationList");
        }

        private void Print()
        {
            throw new NotImplementedException();
        }

        private void SMS()
        {

        }

        private void Email()
        {
            var Donor = Model.SelectedDonation;

            if (EmailService.IsValidEmail(Donor.Email))
            {
                var _Body = new StringBuilder();

                _Body.AppendLine($"Received donation with Thanks From {Donor.TitleDonor}");
                _Body.AppendLine($"for the help in {Donor.TitleDonationType}");
                _Body.Append($" through {Donor.TitlePaymentMode}");

                var _Email = new EmailService(Donor.Email);

                _Email.Subject = $"Donation Receipt # {Donor.Rec_No} dated {Donor.Rec_Date}";
                _Email.Body = _Body.ToString();

                // Send email
                _Email.SendEmail();
            }
        }



        #region Drop Down change 
        public void DonorChanged(int _NewValue)
        {
            Model.SelectedDonation.DonorID = _NewValue;
            Model.TitleDonor = AppliedDB.DataSource.GetTitle(Model.DonorsList, _NewValue);
        }

        public void TypeChanged(int _NewValue)
        {
            Model.SelectedDonation.DonationType = _NewValue;
            Model.TitleType = AppliedDB.DataSource.GetTitle(Model.TypeList, _NewValue);
        }

        public void ModeChanged(int _NewValue)
        {
            Model.SelectedDonation.PaymentMode = _NewValue;
            Model.TitleMode = AppliedDB.DataSource.GetTitle(Model.ModeList, _NewValue);
        }

        public void CurrencyChanged(int _NewValue)
        {
            Model.SelectedDonation.Currency = _NewValue;
            Model.TitleCurrency = AppliedDB.DataSource.GetTitle(Model.CurrencyList, _NewValue);
        }
        #endregion

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
            _AppUser.DataPath = "Database";
            _AppUser.ReportFolder = "Reports";
            _AppUser.PDFFolder = "OutputFiles";
            _AppUser.ClientFolder = "Database";


            return _AppUser;
        }




    }
}
