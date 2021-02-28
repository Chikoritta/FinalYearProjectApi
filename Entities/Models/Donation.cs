using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table(("donations"))]
    public class Donation
    {
        [Key] [Column("id")] public long Id { get; set; }
        [Column("description")] public string Description { get; set; }
        [Column("target")] public long Target { get; set; }
        [Column("current_collected")] public long CurrentCollected { get; set; }
        [Column("receipt_url")] public string ReceiptUrl { get; set; }


        [Column("status_id")] public long? StatusId { get; set; }
        public DonationStatus Status { get; set; }

        [ForeignKey("Orphan")]
        [Column("orphan_id")]
        public long? OrphanId { get; set; }

        public User Orphan { get; set; }

        [ForeignKey("Admin")]
        [Column("admin_id")]
        public long? AdminId { get; set; }

        public User Admin { get; set; }
    }
}