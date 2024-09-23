using Microsoft.AspNetCore.Components;
using MWF.Models;

namespace MWF.Pages.Donation
{
    public partial class DonationList
    {
        public DonationService Model { get; set; }
        private string MyMessage { get; set; } = string.Empty;
        public int? Count => Model.DonationList.Count;

        public DonationList()
        {
            Model = new();
        }
        private void GoDonation(int ID)
        {
            NavManager.NavigateTo($"/DonationForm/{ID}", true);
        }
    }
}
