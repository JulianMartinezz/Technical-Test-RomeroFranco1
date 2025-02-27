using AutoMapper;
using HRMedicalRecordsSystem.DTOs;
using HRMedicalRecordsSystem.Models;

namespace HRMedicalRecordsSystem.AutoMapper
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<MedicalDeleteDTO, TMedicalRecord>().ForMember(dest => dest.StatusId, opt => opt.MapFrom(src => 2));

            CreateMap<MedicalPostDTO, TMedicalRecord>();

            CreateMap<MedicalUpdateDTO, TMedicalRecord>();
        }

    }
}
