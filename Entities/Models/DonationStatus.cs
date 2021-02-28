using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("donation_status")]
    
    public class DonationStatus
    {
        [Key][Column("id")] public long Id { get; set; }
        [Column("name")] public string Name { get; set; }
    }
}