using HRMedicalRecordsSystem.DTOs;
using HRMedicalRecordsSystem.Models;

namespace HRMedicalRecordsSystem.Repositories.interfaces
{
    public interface IHRMedicalRecordRepository
    {
        public Task<List<TMedicalRecord>> GetFilterMedicalRecords(MedicalGetDTO GetDTO);

        public Task<TMedicalRecord> getMedicalRecordByID(int ID);

        public Task<TMedicalRecord> AddMedicalRecord(MedicalPostDTO postDTO);

        public Task<bool> DeleteMedicalRecord(MedicalDeleteDTO DeleteDTO);

        public Task<TMedicalRecord> UpdateMedicalRecord(MedicalUpdateDTO UpdateDTO);

    }
}
