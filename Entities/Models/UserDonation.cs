using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table(("user_donation"))]
    public class UserDonation
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }
        
        [Column("sponsor_id")]
        public long SponsorId { get; set; }
        public User Sponsor { get; set; }
        
        [Column("donation_id")]
        public long DonationId { get; set; }
        public Donation Donation { get; set; }

        [Column("amount")]
        public long Amount { get; set; }
        
    }
}