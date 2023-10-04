using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthClinic.Domains
{
    [Table("MedicalAppointment")]
    public class MedicalAppointment
    {
        [Key]
        public Guid MedicalAppointmentId { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "The 'PatientId' field is required.")]
        public Guid PatientId { get; set; }

        [ForeignKey(nameof(PatientId))]
        public Patient? Patient { get; set; }

        [Required(ErrorMessage = "The 'MedicId' field is required.")]
        public Guid MedicId { get; set; }

        [ForeignKey(nameof(MedicId))]
        public Medic? Medic { get; set; }

        [Required(ErrorMessage = "The 'ClinicId' field is required.")]
        public Guid ClinicId { get; set; }

        [ForeignKey(nameof(ClinicId))]
        public Clinic? Clinic { get; set; }

        [Column(TypeName = "DATE")]
        [Required(ErrorMessage = "The 'Date' field is required.")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = @"dd/MM/yyyy")]
        public DateTime Date { get; set; }

        [Column(TypeName = "TIME")]
        [Required(ErrorMessage = "The 'Time' field is required.")]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = @"hh\:mm")]
        public TimeSpan Time { get; set; }


        [Column(TypeName = "BIT")]
        [Required(ErrorMessage = "The 'IsActive' field is required.")]
        public bool IsActive { get; set; }

    }
}
