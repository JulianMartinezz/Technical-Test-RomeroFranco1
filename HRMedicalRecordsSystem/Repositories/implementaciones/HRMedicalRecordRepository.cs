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
        

        public HRMedicalRecordRepository( HRMedicalContext context)
        {
            _context = context;
            
        }

        public async Task<TMedicalRecord> AddMedicalRecord(TMedicalRecord record)
        {
            await _context.AddAsync(record);
            await _context.SaveChangesAsync();
            return record;
        }

        public async Task<TMedicalRecord> DeleteMedicalRecord(TMedicalRecord delete)
        {
            var record = _context.TMedicalRecords.Where(x => x.StatusId == 1 && x.MedicalRecordId == delete.MedicalRecordId).FirstOrDefault();
            
            _context.TMedicalRecords.Update(record);
            await _context.SaveChangesAsync();
            return record;

        }

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
               
            var MedicalRecordsPage = await query.Skip((getDTO.page - 1) * getDTO.pagesize)
                .Take(getDTO.pagesize)
                .ToListAsync();

            return await query.ToListAsync();
           
        }

        public async Task<TMedicalRecord> getMedicalRecordByID(int ID)
        {
            
            return await _context.TMedicalRecords.FindAsync(ID);
        }

        public async Task<TMedicalRecord> UpdateMedicalRecord(TMedicalRecord Update)
        {
           var UpdateRecord = await _context.TMedicalRecords.FindAsync(Update.MedicalRecordId);

            _context.TMedicalRecords.Update(UpdateRecord);

            await _context.SaveChangesAsync();

            return UpdateRecord;
            
        }

        
    }
}
