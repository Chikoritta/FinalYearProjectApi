using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("users")]
    public class User
    {
        [Key][Column("id")] public long Id { get; set; }
        [Column("name")] public string Name { get; set; }
        [Column("username")] public string Username { get; set; }
        [Column("email")] public string Email { get; set; }
        [Column("birth_date")] public DateTime BirthDate { get; set; }
        [Column("mobile_number")] public string MobileNumber { get; set; }
        [Column("longitude")] public double Longitude { get; set; }
        [Column("latitude")] public double Latitude { get; set; }
        [Column("avatar_url")] public string AvatarUrl { get; set; }

        [Column("gender_type_id")] public long? GenderTypeId { get; set; }
        public Gender GenderType { get; set; }
        
        [Column("user_type_id")] public long? UserTypeId { get; set; }
        public UserType UserType { get; set; }
        
    }
}