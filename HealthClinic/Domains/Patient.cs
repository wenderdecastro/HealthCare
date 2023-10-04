using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthClinic.Domains
{
    [Table("Patient")]
    [Index(nameof(CPF), IsUnique = true)]
    public class Patient
    {

        [Key]
        public Guid PatientId { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "The 'UserId' field is required.")]
        public Guid UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User? User { get; set; }

        //[Required(ErrorMessage = "The 'MedicalRecordId' field is required.")]
    

        //[ForeignKey(nameof(MedicalRecordID))]
        //public MedicalRecords MedicalRecords { get; set; }

        [Required(ErrorMessage = "The 'CPF' field is required.")]
        [Column(TypeName = "VARCHAR(11)")]
        [StringLength(11)]
        public string CPF { get; set; }

        [Column(TypeName = "DATE")]
        [Required(ErrorMessage = "The 'BirthDate' field is required.")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = @"dd/MM/yyyy")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "The 'Genre' field is required.")]
        [Column(TypeName = "CHAR(1)")]
        public char Sex { get; set; }



    }
}
