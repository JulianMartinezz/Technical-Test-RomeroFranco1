using AutoMapper;
using HRMedicalRecordsSystem.DTOs;
using HRMedicalRecordsSystem.Models;

namespace HRMedicalRecordsSystem.AutoMapper
{
    /// <summary>
    /// Mapping class that defines the mapping rules between DTOs and the system's entities.
    /// Uses AutoMapper to perform object transformations.
    /// </summary>
    public class Mapper : Profile
    {
        /// <summary>
        /// Configures the mappings between the DTOs and the corresponding entities.
        /// </summary>
        public Mapper()
        {
            // Mapping from MedicalDeleteDTO to TMedicalRecord
            CreateMap<MedicalDeleteDTO, TMedicalRecord>()
                // The StatusId field in the destination object is always set to 2
                .ForMember(dest => dest.StatusId, opt => opt.MapFrom(src => 2))
                // The DeletionDate field in the destination object is set to the current date (UTC) using DateOnly
                .ForMember(dest => dest.DeletionDate, opt => opt.MapFrom(src => DateOnly.FromDateTime(DateTime.UtcNow)));

            // Mapping from MedicalPostDTO to TMedicalRecord
            CreateMap<MedicalPostDTO, TMedicalRecord>();
            // Mapping from MedicalUpdateDTO to TMedicalRecord
            CreateMap<MedicalUpdateDTO, TMedicalRecord>();
        }

    }
}
