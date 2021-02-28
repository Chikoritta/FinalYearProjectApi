using System.Collections.Generic;
using System.Linq;
using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class UserDonationRepository : RepositoryBase<UserDonation> , IUserDonationRepository
    {
        public UserDonationRepository(FinalYearProjectDbContext context) : base(context)
        {
        }
        
        public IEnumerable<UserDonation> GetAll(bool trackChanges)
        {
            return FindAll(trackChanges)
                .Include(m => m.Donation)
                .Include(m => m.Sponsor.GenderType)
                .Include(m => m.Sponsor.UserType)
                .OrderBy(m => m.Id)
                .ToList();
        }

        public UserDonation GetById(long id, bool trackChanges)
        {
            return FindByCondition(u => u.Id == id , trackChanges)
                .Include(m => m.Donation)
                .Include(m => m.Sponsor.UserType)
                .Include(m => m.Sponsor.UserType)
                .FirstOrDefault();
        }

        public void CreateUserDonation(UserDonation userDonation)
        { 
            Create(userDonation);
            
        }

        public void UpdateUserDonation(UserDonation userDonation)
        {
            Update(userDonation);
        }

        public void DeleteUserDonation(UserDonation userDonation)
        {
            Delete(userDonation);
        }
    }
}