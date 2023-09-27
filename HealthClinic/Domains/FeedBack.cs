﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthClinic.Domains
{
    [Table("FeedBack")]
    public class FeedBack
    {
        [Key]
        public Guid FeedbackId { get; set; }

        [Required(ErrorMessage = "The 'ClinicId' field is required.")]
        public Guid ClinicId { get; set; }

        [ForeignKey(nameof(ClinicId))]
        public Clinic Clinic { get; set; }

        [Required(ErrorMessage = "The 'MedicId' field is required.")]
        public Guid MedicId { get; set; }

        [ForeignKey(nameof(MedicId))]
        public Medic Medic { get; set; }

        [Required(ErrorMessage = "The 'UserId' field is required.")]
        public Guid UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }

        [Required(ErrorMessage = "The 'MedicalAppointmentId' field is required.")]
        public int MedicalAppointmentId { get; set; }

        [ForeignKey(nameof(MedicalAppointmentId))]
        public MedicalAppointment MedicalAppointment { get; set; }

        [Column(TypeName = "VARCHAR(1024)")]
        [Required(ErrorMessage = "The 'Comment' field is required.")]
        public string Comment { get; set; }

        [Required(ErrorMessage = "The 'Rating' field is required.")]
        [Range(0, 10, ErrorMessage = "The value must be between 0 and 10")]
        [Column(TypeName = "INT")]
        public int Rating { get; set; }

        [Required(ErrorMessage = "The 'ShouldShow' field is required.")]
        [Column(TypeName = "BIT")]
        public bool IsShown { get; set; } = false;
    }
}