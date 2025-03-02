using AutoMapper;
using HRMedicalRecordsSystem.Context;
using HRMedicalRecordsSystem.DTOs;
using HRMedicalRecordsSystem.Models;
using HRMedicalRecordsSystem.Repositories.interfaces;
using Microsoft.EntityFrameworkCore;

namespace HRMedicalRecordsSystem.Repositories.implementaciones
{
    public class HRMedicalRecordRepository : IHRMedicalRecordRepository
    {

        private readonly HRMedicalContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="HRMedicalRecordRepository"/> class with the given context.
        /// </summary>
        /// <param name="context">The database context used to interact with the medical records.</param>
        public HRMedicalRecordRepository( HRMedicalContext context)
        {
            _context = context;
            
        }
        /// <summary>
        /// Adds a new medical record to the database.
        /// </summary>
        /// <param name="record">The medical record to be added.</param>
        /// <returns>A task that represents the asynchronous operation, with a result of the added medical record.</returns>
        public async Task<TMedicalRecord> AddMedicalRecord(TMedicalRecord record)
        {
            await _context.AddAsync(record);
            await _context.SaveChangesAsync();
            return record;
        }
        /// <summary>
        /// Marks a medical record as deleted in the database.
        /// </summary>
        /// <param name="delete">The medical record to be deleted.</param>
        /// <returns>A task that represents the asynchronous operation, with a result of the updated medical record.</returns>
        public async Task<TMedicalRecord> DeleteMedicalRecord(TMedicalRecord delete)
        {
            var record = _context.TMedicalRecords.Where(x => x.StatusId == 1 && x.MedicalRecordId == delete.MedicalRecordId).FirstOrDefault();
            
            _context.TMedicalRecords.Update(record);
            await _context.SaveChangesAsync();
            return record;

        }
        /// <summary>
        /// Retrieves a list of medical records based on the specified filter criteria.
        /// </summary>
        /// <param name="getDTO">The data transfer object containing filter parameters for medical records.</param>
        /// <returns>A task that represents the asynchronous operation, with a result of the filtered list of medical records.</returns>
        public async Task<List<TMedicalRecord>> GetFilterMedicalRecords(MedicalGetDTO getDTO)
        {
            var query = _context.TMedicalRecords.AsQueryable();

            if (getDTO.StatusId.HasValue)
            {
                query = query.Where(record => record.StatusId == getDTO.StatusId.Value);
            }

            if (getDTO.StartDate.HasValue)
            {
                query = query.Where(record => record.StartDate >= getDTO.StartDate.Value);
            }

            if (getDTO.EndDate.HasValue)
            {
                query = query.Where(record => record.EndDate <= getDTO.EndDate.Value);
            }

            if (getDTO.MedicalRecordTypeId.HasValue)
            {
                query = query.Where(record => record.MedicalRecordTypeId == getDTO.MedicalRecordTypeId.Value);
            }

            // Paginate the results based on the page and page size specified in the DTO.
            var MedicalRecordsPage = await query.Skip((getDTO.page - 1) * getDTO.pagesize)
                .Take(getDTO.pagesize)
                .ToListAsync();

            return await query.ToListAsync();
           
        }
        /// <summary>
        /// Retrieves a medical record by its unique identifier.
        /// </summary>
        /// <param name="ID">The unique identifier of the medical record.</param>
        /// <returns>A task that represents the asynchronous operation, with a result of the medical record.</returns>
        public async Task<TMedicalRecord> getMedicalRecordByID(int ID)
        {
            
            return await _context.TMedicalRecords.FindAsync(ID);
        }
        /// <summary>
        /// Updates an existing medical record in the database.
        /// </summary>
        /// <param name="Update">The medical record object with updated values.</param>
        /// <returns>A task that represents the asynchronous operation, with a result of the updated medical record.</returns>
        public async Task<TMedicalRecord> UpdateMedicalRecord(TMedicalRecord Update)
        {
           var UpdateRecord = await _context.TMedicalRecords.FindAsync(Update.MedicalRecordId);

            _context.TMedicalRecords.Update(UpdateRecord);

            await _context.SaveChangesAsync();

            return UpdateRecord;
            
        }

        
    }
}
