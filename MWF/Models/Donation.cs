using System.ComponentModel.DataAnnotations;

namespace MWF.Models
{
    public class Donation
    {
        public int DonationId { get; set; }
        public string Rec_No { get; set; }
        public DateTime Rec_Date { get; set; }
        public int DonorId { get; set; }
        public string DonorName { get; set; }

        public string Reference { get; set; }
        public int DonationTypeId { get; set; }
        public DonationType DonationType { get; set; }
        public int PaymentModeId { get; set; }
        public PaymentMode PaymentMode { get; set; }
        public int ChequeNo { get; set; }
        public int CurrencyId { get; set; }
        public Currency Currency { get; set; }
        public decimal Amount { get; set; }
        public string Remarks { get; set; }

                 
            
             }

    } 