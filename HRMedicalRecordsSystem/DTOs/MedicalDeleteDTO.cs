namespace HRMedicalRecordsSystem.DTOs
{
    /// <summary>
    /// Data Transfer Object (DTO) used to represent the data required for deleting a medical record.
    /// </summary>
    public class MedicalDeleteDTO
    {
        // <summary>
        /// Gets or sets the end date for the medical record deletion.
        /// This field is optional, but when provided, it should specify the date when the record is considered deleted.
        /// </summary>
        public DateOnly? EndDate { get; set; }
        /// <summary>
        /// Gets or sets the reason for deleting the medical record.
        /// This field is optional but provides a description or justification for the deletion.
        /// </summary>
        public string? DeletionReason { get; set; }
        /// <summary>
        /// Gets or sets the identifier of the user who performed the deletion.
        /// This field is optional, but it is typically used to track who initiated the deletion.
        /// </summary>
        public string? DeletedBy { get; set; }
        /// <summary>
        /// Gets or sets the unique identifier of the medical record to be deleted.
        /// This field is required as it specifies which medical record is to be deleted.
        /// </summary>
        public int MedicalRecordId { get; set; }


    }
}
