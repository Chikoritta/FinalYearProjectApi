using Contracts;
using Entities;

namespace Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly FinalYearProjectDbContext _context;
        private IDonationRepository _donations;
        private IUserRepository _users;
        private IGenderRepository _genders;
        private IStatusRepository _status;
        private ITypeRepository _type;
        private IUserDonationRepository _userDonation;

        public RepositoryManager(FinalYearProjectDbContext context)
        {
            _context = context;
        }

        public IDonationRepository Donation
        {
            get
            {
                if (_donations == null)
                {
                    _donations = new DonationRepository(_context);
                }

                return _donations;
            }
        }

        public IUserRepository User
        {
            get
            {
                if (_users == null)
                {
                    _users = new UserRepository(_context);
                }

                return _users;
            }
        }

        public IGenderRepository Gender
        {
            get
            {
                if (_genders == null)
                {
                    _genders = new GenderRepository(_context);
                }

                return _genders;
            }
        }


        public IStatusRepository Status
        {
            get
            {
                if (_status == null)
                {
                    _status = new StatusRepository(_context);
                }

                return _status;
            }
        }

        public ITypeRepository Type
        {
            get
            {
                if (_type == null)
                {
                    _type = new TypeRepository(_context);
                }

                return _type;
            }
        }

        public IUserDonationRepository UserDonation
        {
            get
            {
                if (_userDonation == null)
                {
                    _userDonation = new UserDonationRepository(_context);
                }

                return _userDonation;
            }
        }


        public void Save()
        {
            _context.SaveChanges();
        }
    }
}