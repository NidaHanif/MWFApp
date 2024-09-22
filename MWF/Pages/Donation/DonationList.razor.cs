using Microsoft.AspNetCore.Components;
using MWF.Models;

namespace MWF.Pages.Donation
{
    public partial class DonationList
    {
        public DonationService Model { get; set; }
        public int? Count => Model.DonationList.Count;

        public DonationList()
        {
            Model = new();
        }
    }
}
