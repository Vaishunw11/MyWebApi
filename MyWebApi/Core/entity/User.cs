using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWebApi.Core.entity
{
    [Table("Users")]

    public class Users
    {
        [Key]
        [Column("Id")]  // Database column name
        public int UserId { get; set; }

        [Required] public string? Username { get; set; }

        [MaxLength(100)]
        [Required] public string? Password { get; set; }

        public string Role { get; set; } = "User";

        public bool IsActive { get; set; } = false;

    }
}


