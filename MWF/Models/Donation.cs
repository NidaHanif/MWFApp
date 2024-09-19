using System.ComponentModel.DataAnnotations;

namespace MWF.Models
{
    public class Donation
    {
        public int ID { get; set; }
        public int DonorId { get; set; }
        public int DonationTypeId { get; set; }
        public int CurrencyId { get; set; }
        public int PaymentModeId { get; set; }
        public int Rec_No { get; set; }
        public DateTime Rec_Date { get; set; }
        public string DonorName { get; set; }

        [EmailAddress(ErrorMessage = "Enter a valid Email address.")]
        public string Email { get; set; }

        [Phone(ErrorMessage = "Enter a valid Phone number.")]
        public string PhoneNumber { get; set; }

        public string Reference { get; set; }
        public string DonationType { get; set; }

        [Required(ErrorMessage = "Payment mode is required.")]
        public string PaymentMode { get; set; }

        public string ChequeNo { get; set; }
        public DateTime ChequeDate { get; set; }

        public string Currency { get; set; }
        public decimal Amount { get; set; }
        public string Remarks { get; set; }
        public string Status { get; set; }
    }
}
    