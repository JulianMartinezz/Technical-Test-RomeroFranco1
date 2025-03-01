using HRMedicalRecordsSystem.DTOs;
using HRMedicalRecordsSystem.Models;
using HRMedicalRecordsSystem.Responses;

namespace HRMedicalRecordsSystem.Services.Interfaces
{
    public interface IServiceHRMedicalRecords
    {
        Task<BaseResponse<TMedicalRecord>> GetMedicalRecordByID(int id);

        public Task<BaseResponse<List<TMedicalRecord>>> GetFilterMedicalRecords(MedicalGetDTO RecordDTO);

        public Task<BaseResponse<TMedicalRecord>> DeleteMedicalRecord(MedicalDeleteDTO DeleteDTO);

        public Task<BaseResponse<TMedicalRecord>> UpdateMedicalRecord(MedicalUpdateDTO UpdateDTO);

        public Task<BaseResponse<TMedicalRecord>> AddMedicalRecord(MedicalPostDTO postDTO);
    }
}
