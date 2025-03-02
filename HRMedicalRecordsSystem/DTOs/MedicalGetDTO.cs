namespace HRMedicalRecordsSystem.DTOs
{
    /// <summary>
    /// Data Transfer Object (DTO) used for retrieving filtered medical records.
    /// It encapsulates the filter criteria and pagination information.
    /// </summary>
    public class MedicalGetDTO
    {
        /// <summary>
        /// Gets or sets the status ID for filtering medical records by their status.
        /// This field is optional and can be used to filter records based on their current status.
        /// </summary>
        public int? StatusId { get; set; }

        /// <summary>
        /// Gets or sets the start date for filtering medical records.
        /// This field is optional and can be used to filter records created after or on this date.
        /// </summary>
        public DateOnly? StartDate { get; set; }

        /// <summary>
        /// Gets or sets the end date for filtering medical records.
        /// This field is optional and can be used to filter records created before or on this date.
        /// </summary>
        public DateOnly? EndDate { get; set; }

        /// <summary>
        /// Gets or sets the medical record type ID for filtering medical records by their type.
        /// This field is optional and can be used to filter records based on their associated medical record type.
        /// </summary>
        public int? MedicalRecordTypeId { get; set; }

        /// <summary>
        /// Gets or sets the page number for pagination.
        /// This field is required and indicates which page of results should be returned.
        /// </summary>
        public int page { get; set; }

        /// <summary>
        /// Gets or sets the number of records per page for pagination.
        /// This field is required and determines the maximum number of records returned per page.
        /// </summary>
        public int pagesize { get; set; }
    }
}
