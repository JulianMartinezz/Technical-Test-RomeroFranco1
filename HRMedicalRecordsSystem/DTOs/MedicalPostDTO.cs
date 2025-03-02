namespace HRMedicalRecordsSystem.DTOs
{
    /// <summary>
    /// Data Transfer Object (DTO) used for creating a new medical record.
    /// It contains all the required information for adding a new record to the system.
    /// </summary>
    public class MedicalPostDTO
    {
        /// <summary>
        /// Gets or sets the diagnosis description for the medical record.
        /// This field represents the diagnosis of the patient, and is a required field.
        /// </summary>
        public string diagnosis { get; set; }
        /// <summary>
        /// Gets or sets the start date for the medical record.
        /// This field indicates the date when the medical record starts.
        /// </summary>
        public DateOnly StartDate { get; set; }
        /// <summary>
        /// Gets or sets the status ID of the medical record.
        /// This field indicates the status of the record (e.g., active, archived, etc.).
        /// </summary>
        public int StatusId { get; set; }
        /// <summary>
        /// Gets or sets the medical record type ID.
        /// This field indicates the type of medical record (e.g., general, specific type, etc.).
        /// </summary>
        public int MedicalRecordTypeId { get; set; }
        /// <summary>
        /// Gets or sets the file ID associated with the medical record.
        /// This field is a reference to the file in the system linked to the medical record.
        /// </summary>
        public int FileId { get; set; }
        /// <summary>
        /// Gets or sets the username or identifier of the user who created the record.
        /// This field is optional and can be used to track the creator of the record.
        /// </summary>
        public string? CreatedBy { get; set; }
        /// <summary>
        /// Gets or sets the medical record ID.
        /// This field uniquely identifies the medical record in the system.
        /// </summary>
        public int MedicalRecordId { get; set; }
        /// <summary>
        /// Gets or sets the audiometry evaluation status.
        /// This field indicates whether audiometry was performed ("Y" or "N").
        /// </summary>
        public string? Audiometry { get; set; }
        /// <summary>
        /// Gets or sets the position change status.
        /// This field indicates whether a position change was performed ("Y" or "N").
        /// </summary>
        public string? PositionChange { get; set; }
        /// <summary>
        /// Gets or sets the data about the patient's mother.
        /// This field can include additional medical information regarding the patient's mother.
        /// </summary>
        public string? MotherData { get; set; }
        /// <summary>
        /// Gets or sets additional family data for the patient.
        /// This field can include any relevant data about the patient's extended family.
        /// </summary>
        public string? OtherFamilyData { get; set; }
        /// <summary>
        /// Gets or sets the data about the patient's father.
        /// This field can include additional medical information regarding the patient's father.
        /// </summary>
        public string? FatherData { get; set; }
        /// <summary>
        /// Gets or sets whether microsurgery was performed.
        /// This field indicates if microsurgery was performed ("Y" or "N").
        /// </summary>
        public string? ExecuteMicros { get; set; }
        /// <summary>
        /// Gets or sets whether extra procedures were executed.
        /// This field indicates if additional procedures were performed ("Y" or "N").
        /// </summary>
        public string? ExecuteExtra { get; set; }
        /// <summary>
        /// Gets or sets the voice evaluation status.
        /// This field indicates whether a voice evaluation was performed ("Y" or "N").
        /// </summary>
        public string? VoiceEvaluation { get; set; }
        /// <summary>
        /// Gets or sets the creation date of the medical record.
        /// This field records when the medical record was created.
        /// </summary>
        public DateOnly? CreationDate { get; set; }
        /// <summary>
        /// Gets or sets the end date for the medical record.
        /// This field indicates when the medical record ends or expires.
        /// </summary>
        public DateOnly? EndDate { get; set; }
        /// <summary>
        /// Gets or sets the disability status of the patient.
        /// This field indicates whether the patient has a disability ("Y" or "N").
        /// </summary>
        public string? Disability { get; set; }
        /// <summary>
        /// Gets or sets the medical board status of the record.
        /// This field holds the medical board information, if available.
        /// </summary>
        public string? MedicalBoard { get; set; }
        /// <summary>
        /// Gets or sets the deletion reason for the medical record.
        /// This field records the reason why a medical record was deleted.
        /// </summary>
        public string? DeletionReason { get; set; }
        /// <summary>
        /// Gets or sets additional observations about the medical record.
        /// This field can include any relevant notes or comments about the patient's record.
        /// </summary>
        public string? Observations { get; set; }
        /// <summary>
        /// Gets or sets the disability percentage, if applicable.
        /// This field records the percentage of the disability if the patient has a disability.
        /// </summary>
        public decimal? DisabilityPercentage { get; set; }
        /// <summary>
        /// Gets or sets the area change status for the medical record.
        /// This field indicates if the patient's condition has changed in a specific area ("Y" or "N").
        /// </summary>
        public string? AreaChange { get; set; }



    }
}
 