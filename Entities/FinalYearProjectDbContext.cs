using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Entities
{
    public class FinalYearProjectDbContext : DbContext
    {
        public FinalYearProjectDbContext(DbContextOptions<FinalYearProjectDbContext>options) : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Gender> Genders { get; set; }
        public virtual DbSet<UserType> UserTypes { get; set; }
        public virtual DbSet<Donation> Donations { get; set; }
        public virtual DbSet<UserDonation> Mms { get; set; }

    }
}