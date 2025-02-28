using FluentValidation;
using HRMedicalRecordsSystem.DTOs;

namespace HRMedicalRecordsSystem.FluentValidations
{
    public class ValidationsDelete : AbstractValidator<MedicalDeleteDTO>
    {
        public ValidationsDelete() 
        {
            RuleFor(x => x.DeletionReason).NotNull().NotEmpty().WithMessage("DELETION REASON is a required field");

            RuleFor(x => x.EndDate).NotNull().NotEmpty().WithMessage("END DATE is a required field");

            RuleFor(x => x.DeletedBy).NotNull().NotEmpty().WithMessage("DELETED BY is a required field");

            RuleFor(x => x.DeletionDate).NotNull().NotEmpty().WithMessage("DELETION DATE is a required field");

            RuleFor(x => x.MedicalRecordId).NotNull().NotEmpty().WithMessage("MEDICAL RECORD ID is a required field");

        }

    }
}
