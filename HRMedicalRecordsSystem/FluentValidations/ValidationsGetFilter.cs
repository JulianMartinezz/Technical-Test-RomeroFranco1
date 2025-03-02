using FluentValidation;
using HRMedicalRecordsSystem.DTOs;

namespace HRMedicalRecordsSystem.FluentValidations
{
    public class ValidationsGetFilter : AbstractValidator<MedicalGetDTO>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationsGetFilter"/> class.
        /// Defines the validation rules for the <see cref="MedicalGetDTO"/> properties.
        /// </summary>
        public ValidationsGetFilter() 
        {
            // Validation rule for 'StatusId': Ensures that the StatusId is between 1 and 2
            RuleFor(x => x.StatusId).InclusiveBetween(1, 2).WithMessage("Status_ID must exist");
            // Validation rule for 'StartDate': Ensures that StartDate is earlier than EndDate.
            RuleFor(x => x.StartDate).LessThan(x => x.EndDate).WithMessage("START_DATE cannot be later than END_DATE");
            // Validation rule for 'StartDate': Ensures that StartDate is not a future date
            RuleFor(x => x.StartDate).LessThanOrEqualTo(DateOnly.FromDateTime(DateTime.Now)).WithMessage("START_DATE cannot be a future date");
            // Validation rule for 'EndDate': Ensures that EndDate is later than StartDate
            RuleFor(x => x.EndDate).GreaterThan(x => x.StartDate).WithMessage("END_DATE Must be later than START_DATE");
            // Validation rule for 'MedicalRecordTypeId': Ensures that the MedicalRecordTypeId is between 1 and 2
            RuleFor(x => x.MedicalRecordTypeId).InclusiveBetween(1, 2).WithMessage("MEDICAL_RECORD_TYPE_ID must exist");
            // Validation rule for 'page': Ensures that the page number is provided and not empty
            RuleFor(x => x.page).NotNull().NotEmpty().WithMessage("Page Number is a required field");
            // Validation rule for 'pagesize': Ensures that the page size is provided and not empty
            RuleFor(x => x.pagesize).NotNull().NotEmpty().WithMessage("Page Size is a required field");

           


        }
    }
}
