using HealthClinic.Domains;
using Microsoft.EntityFrameworkCore;

namespace HealthClinic.Contexts
{
    public class HealthClinicContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Clinic> Clinics { get; set; }
        public DbSet<MedicalAppointment> MedicalAppointments { get; set; }
        public DbSet<Medic> Medic { get; set; }
        public DbSet<MedicalSpecialty> MedicalSpecialties { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<FeedBack> FeedBacks { get; set; }
        public DbSet<MedicalRecords> MedicalRecords { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = NOTE10-S15; Database = HealthClinic; User = sa; Pwd = Senai@134; TrustServerCertificate = True");

            base.OnConfiguring(optionsBuilder);
        }
    }
}
