using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthCare.Domains
{
    [Table("MedicalAppointmentDomain")]
    public class MedicalAppointment
    {
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = @"dd/MM")]
        public DateTime Date { get; set; }





        

    }
}
