using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("user_type")]
    public class UserType
    {   
        [Key][Column("id")] public long Id { get; set; }
        [Column("type")] public string Type { get; set; }
    }
}