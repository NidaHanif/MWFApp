using MWF.Pages;
using System;
using System.Collections.Generic;
public class DonationService
{
    private List<Donation> donations = new List<Donation>();

    public void AddDonation(Donation donation)
    {
        donations.Add(donation);
    }

    public List<Donation> GetDonations()
    {
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
