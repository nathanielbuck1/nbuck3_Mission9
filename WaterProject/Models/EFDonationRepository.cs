using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WaterProject.Models
{
    public class EFDonationRepository : IDonationRepository
    {
        private BookstoreContext context;

        public EFDonationRepository (BookstoreContext temp)
        {
            context = temp;
        }
        public IQueryable<Donation> Donations => context.Donations.Include(x => x.Lines).ThenInclude(x => x.book);

        public void SaveDonation(Donation donation)
        {
            context.AttachRange(donation.Lines.Select(x => x.book));

            if (donation.DonationId == 0)
            {
                context.Donations.Add(donation);
            }
            context.SaveChanges();
        }
    }
}
