namespace HRMedicalRecordsSystem.DTOs
{
    public class MedicalGetDTO
    {
        public int? StatusId { get; set; }

        public DateOnly? StartDate { get; set; }

        public DateOnly? EndDate { get; set; }

        public int? MedicalRecordTypeId { get; set; }

        public int page { get; set; }

        public int pagesize { get; set; }
    }
}
