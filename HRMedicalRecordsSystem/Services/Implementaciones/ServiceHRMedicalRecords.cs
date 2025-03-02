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
    /// <summary>
    /// Service class for managing HR medical records. It interacts with the repository layer and handles the business logic
    /// for CRUD operations related to medical records.
    /// </summary>
    public class ServiceHRMedicalRecords : IServiceHRMedicalRecords
    {
        private readonly IHRMedicalRecordRepository _repository;

        private readonly ValidationsDelete _validationsDelete;

        private readonly ValidationsGetFilter _validationsGetFilter;

        private readonly ValidationsUpdate _validationsUpdate;

        private readonly ValidationsPost _validationsPost;

        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceHRMedicalRecords"/> class.
        /// </summary>
        /// <param name="repository">The medical record repository.</param>
        /// <param name="validationsDelete">Validator for delete operations.</param>
        /// <param name="validationsGetFilter">Validator for filter operations.</param>
        /// <param name="validationsUpdate">Validator for update operations.</param>
        /// <param name="validationsPost">Validator for post operations.</param>
        /// <param name="mapper">The automapper instance for mapping DTOs to entities and vice versa.</param>
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

        /// <summary>
        /// Adds a new medical record.
        /// </summary>
        /// <param name="postDTO">The DTO containing the data for the new medical record.</param>
        /// <returns>A response indicating whether the operation was successful, including the created record or an error message.</returns>
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

        /// <summary>
        /// Deletes an existing medical record.
        /// </summary>
        /// <param name="DeleteDTO">The DTO containing the ID of the medical record to delete.</param>
        /// <returns>A response indicating whether the operation was successful or not, including the deleted record or an error message.</returns>
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

        /// <summary>
        /// Retrieves a list of medical records based on filtering criteria.
        /// </summary>
        /// <param name="GetDTO">The DTO containing the filter criteria for retrieving records.</param>
        /// <returns>A response containing a list of filtered medical records or an error message.</returns>
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

        /// <summary>
        /// Retrieves a medical record by its ID.
        /// </summary>
        /// <param name="id">The ID of the medical record to retrieve.</param>
        /// <returns>A response containing the medical record if found, or an error message if not found.</returns>
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

        /// <summary>
        /// Updates an existing medical record.
        /// </summary>
        /// <param name="UpdateDTO">The DTO containing the updated data for the medical record.</param>
        /// <returns>A response indicating whether the operation was successful, including the updated record or an error message.</returns>

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


