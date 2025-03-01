using AutoMapper;
using HRMedicalRecordsSystem.DTOs;
using HRMedicalRecordsSystem.FluentValidations;
using HRMedicalRecordsSystem.Models;
using HRMedicalRecordsSystem.Repositories.interfaces;
using HRMedicalRecordsSystem.Responses;
using HRMedicalRecordsSystem.Services.Interfaces;

namespace HRMedicalRecordsSystem.Services.Implementaciones
{
    public class ServiceHRMedicalRecords : IServiceHRMedicalRecords
    {
        private readonly IHRMedicalRecordRepository _repository;

        private readonly ValidationsDelete _validationsDelete;

        private readonly ValidationsGetFilter _validationsGetFilter;

        private readonly ValidationsUpdate _validationsUpdate;

        private readonly ValidationsPost _validationsPost;

        private readonly IMapper _mapper;

        public ServiceHRMedicalRecords(IHRMedicalRecordRepository repository, ValidationsDelete validationsDelete,
            ValidationsGetFilter validationsGetFilter, ValidationsUpdate ValidationsUpdate, 
            ValidationsPost ValidationPost,IMapper mapper)
        {
            _repository = repository;
            _validationsDelete = validationsDelete;
            _validationsPost = ValidationPost; 
            _validationsUpdate = ValidationsUpdate;
            _validationsGetFilter = validationsGetFilter;
            _mapper = mapper;


        }


        public async Task<BaseResponse<TMedicalRecord>> AddMedicalRecord(MedicalPostDTO postDTO)
        {

            var validationResult = _validationsPost.Validate(postDTO);
            if (!validationResult.IsValid) 
            {
                return BaseResponse<TMedicalRecord>.BadRequestResponse(validationResult.Errors.ToString());
            }
            try
            {
                var result = await _repository.AddMedicalRecord(_mapper.Map<TMedicalRecord>(postDTO));
                return BaseResponse<TMedicalRecord>.SuccessResponse(result, 1);
            }
            catch (Exception ex) 
            {
                return BaseResponse<TMedicalRecord>.ErrorResponse(ex.Message);
            }


        }

        public Task<bool> DeleteMedicalRecord(MedicalDeleteDTO DeleteDTO)
        {
            throw new NotImplementedException();
        }

        public Task<List<TMedicalRecord>> GetFilterMedicalRecords(TMedicalRecord Record)
        {
            throw new NotImplementedException();
        }

        public Task<TMedicalRecord> GetMedicalRecordByID(int id)
        {
            throw new NotImplementedException();
        }

        public Task<TMedicalRecord> UpdateMedicalRecord(TMedicalRecord Update)
        {
            throw new NotImplementedException();
        }

        
    }
}
