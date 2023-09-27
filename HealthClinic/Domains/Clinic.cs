using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthClinic.Domains
{
    [Table("Clinic")]
    [Index(nameof(CPNJ), IsUnique = true)]
    public class Clinic
    {
        [Key]
        public Guid ClinicId { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(256)")]
        public string TradeName { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(14)")]
        [StringLength(14)]
        public string CPNJ { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(10)")]
        public string BusinessHours { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(256)")]
        public string CompanyName { get; set; }

    }
}
