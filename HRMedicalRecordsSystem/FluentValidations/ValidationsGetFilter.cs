using FluentValidation;
using HRMedicalRecordsSystem.DTOs;

namespace HRMedicalRecordsSystem.FluentValidations
{
    public class ValidationsGetFilter : AbstractValidator<MedicalGetDTO>
    {
        public ValidationsGetFilter() 
        {
            RuleFor(x => x.StatusId).InclusiveBetween(1, 2).WithMessage("Status_ID must exist");

            RuleFor(x => x.StartDate).LessThan(x => x.EndDate).WithMessage("START_DATE cannot be later than END_DATE");

            RuleFor(x => x.StartDate).LessThanOrEqualTo(DateOnly.FromDateTime(DateTime.Now)).WithMessage("START_DATE cannot be a future date");

            RuleFor(x => x.EndDate).GreaterThan(x => x.StartDate).WithMessage("END_DATE Must be later than START_DATE");

            RuleFor(x => x.MedicalRecordTypeId).InclusiveBetween(1, 2).WithMessage("MEDICAL_RECORD_TYPE_ID must exist");

            RuleFor(x => x.page).NotNull().NotEmpty().WithMessage("Page Number is a required field");

            RuleFor(x => x.pagesize).NotNull().NotEmpty().WithMessage("Page Size is a required field");

           


        }
    }
}
