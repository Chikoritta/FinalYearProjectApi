using System.Collections.Generic;
using System.Linq;
using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class DonationRepository : RepositoryBase<Donation>, IDonationRepository
    {
        public DonationRepository(FinalYearProjectDbContext context) : base(context)
        {
        }

        public IEnumerable<Donation> GetAll(bool trackChanges)
        {
            return FindAll(trackChanges)
                .Include(d => d.Admin.UserType)
                .Include(d => d.Admin.GenderType)
                .Include(d => d.Orphan.UserType)
                .Include(d => d.Orphan.GenderType)
                .Include(d => d.Status)
                .OrderBy(d => d.Id)
                .ToList();
        }

        public Donation GetDonationById(long id, bool trackChanges)
        {
            return FindByCondition(d => d.Id == id, trackChanges)
                .Include(d => d.Status)
                .FirstOrDefault();
        }

        public void CreateDonation(Donation donation)
        {
            Create(donation);
        }

        public void UpdateDonation(Donation donation)
        {
            Update(donation);
        }

        public void DeleteDonation(Donation donation)
        {
            Delete(donation);
        }
    }
}