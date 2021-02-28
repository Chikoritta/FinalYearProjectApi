using System.Collections.Generic;
using Entities.Models;

namespace Contracts
{
    public interface ITypeRepository
    {
        IEnumerable<UserType> GetAll(bool trackChanges);
        UserType GetById(long id, bool trackChanges);
        void CreateType(UserType type);
        void UpdateType(UserType type);
        void DeleteType(UserType type);
        
    }
}