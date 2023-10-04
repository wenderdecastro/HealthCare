using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthClinic.Domains
{
    [Table("MedicalRecords")]
    [Index(nameof(PatientId), IsUnique = true)]
    public class MedicalRecords
    {
        [Key]
        public Guid MedicalRecordID { get; set; }

        [Required(ErrorMessage = "The 'PatientId' field is required.")]
        public Guid PatientId { get; set; }

        [ForeignKey(nameof(PatientId))]
        public Patient? Patient { get; set; }

        [Required(ErrorMessage = "The 'ChiefComplaint' field is required.")]
        [Column(TypeName = "VARCHAR(5096)")]
        public string ChiefComplaint { get; set; }
        public string Symptoms { get; set; } = "None";

        [Column(TypeName = "VARCHAR(5096)")]
        public string Allergies { get; set; } = "None";

        [Required(ErrorMessage = "The 'ChiefComplaint' field is required.")]
        [Column(TypeName = "VARCHAR(5096)")]
        public string Diagnostic { get; set; } = "None";

        [Column(TypeName = "VARCHAR(5096)")]
        public string Prescription { get; set; } = "None";

        [Column(TypeName = "VARCHAR(5096)")]
        public string MedicalHistory { get; set; } = "None";

        /*
        [Column(TypeName = "VARCHAR()")]
        public string CID { get; set; } = "N/A";
        */

    }
}
