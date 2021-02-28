using System.Collections.Generic;
using Entities.Models;

namespace Contracts
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll(bool trackChanges);
        User GetById(long id, bool trackChanges);
        User GetByUsername(string username , bool trackChanges);
        void CreateUser(User user);
        void UpdateUser(User user);
        void DeleteUser(User user);
    }
}