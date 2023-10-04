using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HealthClinic.Domains
{
    [Table("Medic")]
    [Index(nameof(CRM), IsUnique = true)]
    public class Medic
    {
        [Key]
        public Guid MedicId { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "The 'UserId' field is required.")]
        public Guid UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User? User { get; set; }

        [Required(ErrorMessage = "The 'SpecialtyId' field is required.")]
        public Guid SpecialtyId { get; set; }

        [ForeignKey(nameof(SpecialtyId))]
        public MedicalSpecialty? Specialty { get; set; }

        [Required(ErrorMessage = "The 'ClinicId' field is required.")]
        public Guid ClinicId { get; set; }

        [ForeignKey(nameof(ClinicId))]
        public Clinic? Clinic { get; set; }

        [Column(TypeName = "VARCHAR(8)")]
        [StringLength(8)]
        [Required(ErrorMessage = "The 'CRM' field is required.")]
        public string CRM { get; set; }
    }
}
