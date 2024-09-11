using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MWF.Data;
    public class DonationDbContext : DbContext
    {
        public DonationDbContext(DbContextOptions<DonationDbContext> options) : base(options) { }

        public DbSet<Donor> Donors { get; set; }
        public DbSet<Donation> Donations { get; set; }
        public DbSet<DonationType> DonationTypes { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<PaymentMode> PaymentModes { get; set; }
    }


