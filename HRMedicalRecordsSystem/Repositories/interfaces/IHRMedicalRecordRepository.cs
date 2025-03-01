using HRMedicalRecordsSystem.DTOs;
using HRMedicalRecordsSystem.Models;

namespace HRMedicalRecordsSystem.Repositories.interfaces
{
    public interface IHRMedicalRecordRepository
    {
        public Task<List<TMedicalRecord>> GetFilterMedicalRecords(MedicalGetDTO GetDTO);

        public Task<TMedicalRecord> getMedicalRecordByID(int ID);

        public Task<TMedicalRecord> AddMedicalRecord(TMedicalRecord addRecord);

        public Task<bool> DeleteMedicalRecord(TMedicalRecord Delete);

        public Task<TMedicalRecord> UpdateMedicalRecord(TMedicalRecord Update);

    }
}
