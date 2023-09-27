using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthCare.Domains
{
    [Table("UserDomain")]
    public class User
    {
        [Key]

        public Guid UserId { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "The 'UserID' field is required.")]
        [Column(TypeName = "VARCHAR(64)")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The 'Email' field is required.")]
        [Column(TypeName = "VARCHAR(256)")]
        public string Email { get; set; }

        [Required(ErrorMessage = "The 'Password' field is required.")]
        [Column(TypeName = "VARCHAR(60)")]
        public string Password { get; set; }

        [Required(ErrorMessage = "The 'IsAdmin' field is required.")]
        [Column(TypeName = "BIT")]
        public bool IsAdmin { get; set; } = false;

    }
}
