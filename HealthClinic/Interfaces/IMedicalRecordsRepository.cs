using HealthClinic.Domains;

namespace HealthClinic.Interfaces
{
    public interface IMedicalRecordsRepository
    {
        void Create(MedicalRecords medRecord);
        List<MedicalRecords> List();
        MedicalRecords SearchByPatient(Guid patientId);
        void Update(Guid medRecordId, MedicalRecords medRecord);
    }
}
