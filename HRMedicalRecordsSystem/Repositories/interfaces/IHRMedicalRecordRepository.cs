using HRMedicalRecordsSystem.DTOs;
using HRMedicalRecordsSystem.Models;

namespace HRMedicalRecordsSystem.Repositories.interfaces
{
    public interface IHRMedicalRecordRepository
    {
        /// <summary>
        /// Retrieves a list of medical records based on the specified filter criteria.
        /// </summary>
        /// <param name="GetDTO">The data transfer object containing filter parameters for medical records.</param>
        /// <returns>A task that represents the asynchronous operation, with a result of a list of filtered medical records.</returns>
        public Task<List<TMedicalRecord>> GetFilterMedicalRecords(MedicalGetDTO GetDTO);

        /// <summary>
        /// Retrieves a medical record by its unique identifier.
        /// </summary>
        /// <param name="ID">The unique identifier of the medical record.</param>
        /// <returns>A task that represents the asynchronous operation, with a result of the medical record.</returns>
        public Task<TMedicalRecord> getMedicalRecordByID(int ID);
        /// <summary>
        /// Adds a new medical record to the system.
        /// </summary>
        /// <param name="addRecord">The medical record object to be added.</param>
        /// <returns>A task that represents the asynchronous operation, with a result of the added medical record.</returns>
        public Task<TMedicalRecord> AddMedicalRecord(TMedicalRecord addRecord);
        /// <summary>
        /// Deletes an existing medical record from the system.
        /// </summary>
        /// <param name="Delete">The medical record object to be deleted.</param>
        /// <returns>A task that represents the asynchronous operation, with a result of the deleted medical record.</returns>
        public Task<TMedicalRecord> DeleteMedicalRecord(TMedicalRecord Delete);
        /// <summary>
        /// Updates an existing medical record in the system.
        /// </summary>
        /// <param name="Update">The medical record object with updated values.</param>
        /// <returns>A task that represents the asynchronous operation, with a result of the updated medical record.</returns>
        public Task<TMedicalRecord> UpdateMedicalRecord(TMedicalRecord Update);

    }
}
