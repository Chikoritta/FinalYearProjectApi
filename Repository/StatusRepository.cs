using System.Collections.Generic;
using System.Linq;
using Contracts;
using Entities;
using Entities.Models;

namespace Repository
{
    public class StatusRepository : RepositoryBase<DonationStatus> , IStatusRepository
    {
        public StatusRepository(FinalYearProjectDbContext context) : base(context)
        {
        }

        public IEnumerable<DonationStatus> GetAll(bool trackChanges)
        {
            return FindAll(trackChanges)
                .OrderBy(s => s.Id)
                .ToList();
        }

        public DonationStatus GetById(long id, bool trackChanges)
        {
            return FindByCondition(s => s.Id == id, trackChanges).FirstOrDefault();
        }

        public void CreateStatus(DonationStatus status)
        {
            Create(status);
        }

        public void UpdateStatus(DonationStatus status)
        {
            Update(status);
        }

        public void DeleteStatus(DonationStatus status)
        {
            Delete(status);
        }
    }
}