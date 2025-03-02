namespace HRMedicalRecordsSystem.DTOs
{
    public class MedicalDeleteDTO
    {
        public DateOnly? EndDate { get; set; }
        public string? DeletionReason { get; set; }
        public string? DeletedBy { get; set; }
        public int MedicalRecordId { get; set; }


    }
}
