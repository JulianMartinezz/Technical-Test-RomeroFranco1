using AutoMapper;
using HRMedicalRecordsSystem.DTOs;
using HRMedicalRecordsSystem.FluentValidations;
using HRMedicalRecordsSystem.Models;
using HRMedicalRecordsSystem.Repositories.interfaces;
using HRMedicalRecordsSystem.Responses;
using HRMedicalRecordsSystem.Services.Interfaces;
using System.ComponentModel.DataAnnotations;

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

        public async Task<BaseResponse<TMedicalRecord>> DeleteMedicalRecord(MedicalDeleteDTO DeleteDTO)
        {
            var ValidationResult = _validationsDelete.Validate(DeleteDTO);
            if (!ValidationResult.IsValid) 
            {
                return BaseResponse<TMedicalRecord>.BadRequestResponse(ValidationResult.Errors.ToString());
            }
            TMedicalRecord Delete = await _repository.getMedicalRecordByID(DeleteDTO.MedicalRecordId);
            if(Delete.Equals(null))   
            {
                return BaseResponse<TMedicalRecord>.NotFoundResponse();
            }
            if(Delete.StatusId == 2)
            {
                return BaseResponse<TMedicalRecord>.BadRequestResponse("You are trying to delete a deleted Record");
            }
            try 
            {
                TMedicalRecord result = await _repository.DeleteMedicalRecord(_mapper.Map(DeleteDTO, Delete));
                return BaseResponse<TMedicalRecord>.SuccessResponse(result, 1);
            }
            catch(Exception ex) 
            {
                return BaseResponse<TMedicalRecord>.ErrorResponse(ex.Message);
            }


        }

        public async Task<BaseResponse<List<TMedicalRecord>>> GetFilterMedicalRecords(MedicalGetDTO GetDTO)
        {
            var validationResult = _validationsGetFilter.Validate(GetDTO);
            if (!validationResult.IsValid) 
            {
                return BaseResponse<List<TMedicalRecord>>.BadRequestResponse(validationResult.Errors.ToString());
            }

            try
            {
                var result = await _repository.GetFilterMedicalRecords(GetDTO);
                int totalRows = result.Count();
                return BaseResponse<List<TMedicalRecord>>.SuccessResponse(result,totalRows);

            }
            catch(Exception ex) 
            {
                return BaseResponse<List<TMedicalRecord>>.ErrorResponse(ex.Message);
            }

        }

        public async Task<BaseResponse<TMedicalRecord>> GetMedicalRecordByID(int id)
        {
            if (id.Equals(0))
            {
                return BaseResponse<TMedicalRecord>.BadRequestResponse("ID cant be equal to 0");
            }
            try
            {
                TMedicalRecord result = await _repository.getMedicalRecordByID(id);
                if (result.Equals(null))
                {
                    return BaseResponse<TMedicalRecord>.NotFoundResponse();

                }
                return BaseResponse<TMedicalRecord>.SuccessResponse(result, 1);
            }
            catch(Exception ex) 
            {
                return BaseResponse<TMedicalRecord>.ErrorResponse(ex.Message);
            }
        }

        public async Task<BaseResponse<TMedicalRecord>> UpdateMedicalRecord(MedicalUpdateDTO UpdateDTO)
        {
            var validationResult = _validationsUpdate.Validate(UpdateDTO);
            if (!validationResult.IsValid)
            {
                return BaseResponse<TMedicalRecord>.BadRequestResponse(validationResult.Errors.ToString());
            }
            TMedicalRecord result = await _repository.getMedicalRecordByID(UpdateDTO.MedicalRecordId);
            if (result.StatusId.Equals(2))
            {
                return BaseResponse<TMedicalRecord>.BadRequestResponse("You tried to update a deleted Record");
            }
            if (result.Equals(null)) 
            {
                return BaseResponse<TMedicalRecord>.NotFoundResponse();
            }
            try 
            {
                TMedicalRecord update = await _repository.UpdateMedicalRecord(_mapper.Map(UpdateDTO, result));
                return BaseResponse<TMedicalRecord>.SuccessResponse(update, 1);
            }
            catch(Exception ex) 
            {
                return BaseResponse<TMedicalRecord>.ErrorResponse(ex.Message);
            }

            
            

            

        }
    }

        

        
    
}


