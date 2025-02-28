namespace HRMedicalRecordsSystem.DTOs
{
    public class MedicalDeleteDTO
    {
        public DateOnly? DeletionDate { get; set; }
        public DateOnly? EndDate { get; set; }
        public string? DeletionReason { get; set; }
        public string? DeletedBy { get; set; }
        public int MedicalRecordId { get; set; }


    }
}
