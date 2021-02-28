using System.Collections.Generic;
using Entities.Models;

namespace Contracts
{
    public interface IDonationRepository
    {
        IEnumerable<Donation> GetAll(bool trackChanges);
        Donation GetDonationById(long id, bool trackChanges);
        void CreateDonation(Donation donation);
        void UpdateDonation(Donation donation);
        void DeleteDonation(Donation donation);
    }
}