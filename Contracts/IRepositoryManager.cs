namespace Contracts
{
    public interface IRepositoryManager
    {
        public IDonationRepository Donation { get; }
        public IUserRepository User { get; } 
        public IGenderRepository Gender { get; }
        public IStatusRepository Status { get; }   
        public ITypeRepository Type { get; }  
        
        public IUserDonationRepository UserDonation { get; }  

        void Save();
    }
}