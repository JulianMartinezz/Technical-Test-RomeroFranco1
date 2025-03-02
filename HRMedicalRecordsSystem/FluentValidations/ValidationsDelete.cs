using FluentValidation;
using HRMedicalRecordsSystem.DTOs;

namespace HRMedicalRecordsSystem.FluentValidations
{
    public class ValidationsDelete : AbstractValidator<MedicalDeleteDTO>
    { /// <summary>
      /// Initializes a new instance of the <see cref="ValidationsDelete"/> class.
      /// Defines the validation rules for the <see cref="MedicalDeleteDTO"/> properties.
      /// </summary>
        public ValidationsDelete() 
        {
            // Validation rule for 'DeletionReason': Ensures the reason for deletion is provided and not empty
            RuleFor(x => x.DeletionReason).NotNull().NotEmpty().WithMessage("DELETION REASON is a required field");

            // Validation rule for 'EndDate': Ensures the end date of the medical record is provided and not empty
            RuleFor(x => x.EndDate).NotNull().NotEmpty().WithMessage("END DATE is a required field");

            // Validation rule for 'DeletedBy': Ensures the identifier of the user who deleted the record is provided and not empty
            RuleFor(x => x.DeletedBy).NotNull().NotEmpty().WithMessage("DELETED BY is a required field");

            // Validation rule for 'MedicalRecordId': Ensures the ID of the medical record to be deleted is provided and not empty
            RuleFor(x => x.MedicalRecordId).NotNull().NotEmpty().WithMessage("MEDICAL RECORD ID is a required field");

        }

    }
}
