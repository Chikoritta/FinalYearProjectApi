using System.Collections.Generic;
using System.Linq;
using Contracts;
using Entities;
using Entities.Models;

namespace Repository
{
    public class TypeRepository : RepositoryBase<UserType> , ITypeRepository
    {
        public TypeRepository(FinalYearProjectDbContext context) : base(context)
        {
        }

        public IEnumerable<UserType> GetAll(bool trackChanges)
        {
            return FindAll(trackChanges)
                .OrderBy(t => t.Id)
                .ToList();
        }

        public UserType GetById(long id, bool trackChanges)
        {
            return FindByCondition(t => t.Id == id, trackChanges).FirstOrDefault();
        }

        public void CreateType(UserType type)
        {
            Create(type);
        }

        public void UpdateType(UserType type)
        {
            Update(type);
        }

        public void DeleteType(UserType type)
        {
            Delete(type);
        }
    }
}