using HRMedicalRecordsSystem.DTOs;
using HRMedicalRecordsSystem.Models;
using HRMedicalRecordsSystem.Responses;

namespace HRMedicalRecordsSystem.Services.Interfaces
{
    /// <summary>
    /// An interface that defines the operations available for managing HR medical records.
    /// </summary>
    public interface IServiceHRMedicalRecords
    {
        /// <summary>
        /// Retrieves a medical record by its ID.
        /// </summary>
        /// <param name="id">The ID of the medical record to retrieve.</param>
        /// <returns>A response containing the requested medical record, or an error if not found.</returns>
        Task<BaseResponse<TMedicalRecord>> GetMedicalRecordByID(int id);

        /// <summary>
        /// Retrieves medical records based on filter criteria.
        /// </summary>
        /// <param name="RecordDTO">The filter criteria for retrieving the medical records.</param>
        /// <returns>A response containing a list of medical records that match the given filter criteria.</returns>
        public Task<BaseResponse<List<TMedicalRecord>>> GetFilterMedicalRecords(MedicalGetDTO RecordDTO);
        /// <summary>
        /// Deletes a medical record based on the provided delete criteria.
        /// </summary>
        /// <param name="DeleteDTO">The criteria for deleting a medical record.</param>
        /// <returns>A response indicating the success or failure of the delete operation.</returns>
        public Task<BaseResponse<TMedicalRecord>> DeleteMedicalRecord(MedicalDeleteDTO DeleteDTO);
        /// <summary>
        /// Updates an existing medical record based on the provided update criteria.
        /// </summary>
        /// <param name="UpdateDTO">The updated data for the medical record.</param>
        /// <returns>A response indicating the success or failure of the update operation.</returns>
        public Task<BaseResponse<TMedicalRecord>> UpdateMedicalRecord(MedicalUpdateDTO UpdateDTO);
        /// <summary>
        /// Adds a new medical record based on the provided post data.
        /// </summary>
        /// <param name="postDTO">The data for the new medical record.</param>
        /// <returns>A response indicating the success or failure of the add operation.</returns>
        public Task<BaseResponse<TMedicalRecord>> AddMedicalRecord(MedicalPostDTO postDTO);
    }
}
