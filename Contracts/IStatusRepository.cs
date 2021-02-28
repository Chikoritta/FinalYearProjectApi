using System.Collections.Generic;
using Entities.Models;

namespace Contracts
{
    public interface IStatusRepository
    {
        IEnumerable<DonationStatus> GetAll( bool trackChanges);
        DonationStatus GetById(long id, bool trackChanges);
        void CreateStatus(DonationStatus status);
        void UpdateStatus(DonationStatus status);
        void DeleteStatus(DonationStatus status);
    }
}