using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthClinic.Domains
{
    [Table("MedicalSpecialty")]
    public class MedicalSpecialty
    {
        [Key]
        public Guid SpecialtyId { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "The 'Specialty' field is required.")]
        [Column(TypeName = "VARCHAR(64)")]
        public string Specialty { get; set; }
    }
}
