using System.Collections.Generic;
using Entities.Models;

namespace Contracts
{
    public interface IUserDonationRepository
    {
        IEnumerable<UserDonation> GetAll(bool trackChanges);
        UserDonation GetById(long id, bool trackChanges);
        void CreateUserDonation(UserDonation userDonation);
        void UpdateUserDonation(UserDonation userDonation);
        void DeleteUserDonation(UserDonation userDonation);
        
    }
}