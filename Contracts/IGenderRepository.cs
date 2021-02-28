using System.Collections.Generic;
using Entities.Models;

namespace Contracts
{
    public interface IGenderRepository
    {
        IEnumerable<Gender> GetAll(bool trackChanges);
        Gender GetById(long id,bool trackChanges);
        void CreateGender(Gender gender);
        void UpdateGender(Gender gender);
        void DeleteGender(Gender gender);

    }
}