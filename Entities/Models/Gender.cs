using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("gender")]
    public class Gender
    {
        [Key][Column("id")] public long Id { get; set; }
        [Column("type")] public string Type { get; set; }
    }
}