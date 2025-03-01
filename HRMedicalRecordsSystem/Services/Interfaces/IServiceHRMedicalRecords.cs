using HRMedicalRecordsSystem.DTOs;
using HRMedicalRecordsSystem.Models;
using HRMedicalRecordsSystem.Responses;

namespace HRMedicalRecordsSystem.Services.Interfaces
{
    public interface IServiceHRMedicalRecords
    {
        Task<TMedicalRecord> GetMedicalRecordByID(int id);

        public Task<List<TMedicalRecord>> GetFilterMedicalRecords(TMedicalRecord Record);

        public Task<bool> DeleteMedicalRecord(MedicalDeleteDTO DeleteDTO);

        public Task<TMedicalRecord> UpdateMedicalRecord(TMedicalRecord Update);

        public Task<BaseResponse<TMedicalRecord>> AddMedicalRecord(MedicalPostDTO postDTO);
    }
}
