using System.Collections.Generic;
using System.Linq;
using Contracts;
using Entities;
using Entities.Models;

namespace Repository
{
    public class GenderRepository : RepositoryBase<Gender>, IGenderRepository
    {
        public GenderRepository(FinalYearProjectDbContext context) : base(context)
        {
        }

        public IEnumerable<Gender> GetAll(bool trackChanges)
        {
            return FindAll(trackChanges)
                .OrderBy(g => g.Id)
                .ToList();
        }

        public Gender GetById(long id, bool trackChanges)
        {
            return FindByCondition(g => g.Id == id , trackChanges)
                .FirstOrDefault();
        }
        public void CreateGender(Gender gender)
        {
            Create(gender);
        }

        public void UpdateGender(Gender gender)
        {
            Update(gender);
        }

        public void DeleteGender(Gender gender)
        {
           Delete(gender);
        }
    }
}