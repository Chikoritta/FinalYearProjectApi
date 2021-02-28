using System.Collections.Generic;
using System.Linq;
using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class UserRepository : RepositoryBase<User>,IUserRepository
    {
        public UserRepository(FinalYearProjectDbContext context): base(context)
        {
        }

        public IEnumerable<User> GetAll(bool trackChanges)
        {
            return FindAll(trackChanges)
                .Include(u => u.GenderType)
                .Include(u => u.UserType)
                .OrderBy(u => u.Id)
                .ToList();
            
        }

        public User GetById(long id, bool trackChanges)
        {
            return FindByCondition(u => u.Id == id, trackChanges)
                .Include(u => u.GenderType)
                .Include(u => u.UserType)
                .FirstOrDefault();
            
        }

        public User GetByUsername(string username, bool trackChanges)
        {
            return FindByCondition(u => u.Username == username, trackChanges).FirstOrDefault();
        }

        public void CreateUser(User user)
        {
            Create(user);
        }

        public void UpdateUser(User user)
        {
            Update(user);
        }

        public void DeleteUser(User user)
        {
            Delete(user);
        }
    }
}