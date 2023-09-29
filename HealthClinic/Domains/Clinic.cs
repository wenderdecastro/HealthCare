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

        [Required(ErrorMessage = "The 'TradeName' field is required.")]
        [Column(TypeName = "VARCHAR(256)")]
        public string TradeName { get; set; }

        [Required(ErrorMessage = "The 'CPNJ' field is required.")]
        [Column(TypeName = "VARCHAR(14)")]
        [StringLength(14)]
        public string CPNJ { get; set; }

        [Required(ErrorMessage = "The 'OpeningTime' field is required.")]
        [Column(TypeName = "TIME")  ]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = @"hh\:mm:ss")]
        public TimeSpan? OpeningTime { get; set; }
        
        [Required(ErrorMessage = "The 'ClosingTime' field is required.")]
        [Column(TypeName = "TIME")]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = @"hh\:mm:ss")]
        public TimeSpan? ClosingTime { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(256)")]
        public string CompanyName { get; set; }

    }
}
