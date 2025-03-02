using FluentValidation;
using HRMedicalRecordsSystem.DTOs;

namespace HRMedicalRecordsSystem.FluentValidations
{
    public class ValidationsPost : AbstractValidator<MedicalPostDTO>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationsPost"/> class
        /// Defines the validation rules for the <see cref="MedicalPostDTO"/> properties
        /// </summary>
        public ValidationsPost() 
        {
            // Validation rule for 'diagnosis': Ensures diagnosis is not null and its length is no more than 100 characters.
            RuleFor(x => x.diagnosis).NotNull().MaximumLength(100).WithMessage("Diagnosis has a maximum of 100 characters");

            // Validation rule for 'StartDate' and 'EndDate': Ensures that StartDate is earlier than EndDate.
            RuleFor(x => x.StartDate).LessThan(x => x.EndDate).WithMessage("START_DATE cannot be later than END_DATE");

            // Validation rule for 'StatusId': Ensures StatusId is between 1 and 2, and it is not null.
            RuleFor(x => x.StatusId).InclusiveBetween(1, 2).NotNull().WithMessage("Status_ID must exist");

            // Validation rule for 'MedicalRecordTypeId': Ensures MedicalRecordTypeId is between 1 and 2, and it is not null.
            RuleFor(x => x.MedicalRecordTypeId).InclusiveBetween(1, 2).NotNull().WithMessage("MEDICAL_RECORD_TYPE_ID must exist");

            // Validation rule for 'FileId': Ensures FileId is not null and not empty
            RuleFor(x => x.FileId).NotNull().NotEmpty().WithMessage("FILE_ID is a required field");

            // Validation rule for 'CreatedBy': Ensures CreatedBy is not null
            RuleFor(x => x.CreatedBy).NotNull().WithMessage("CREATED_BY is a required field");

            // Validation rule for 'MedicalRecordId': Ensures MedicalRecordId is not null and not empty
            RuleFor(x => x.MedicalRecordId).NotNull().NotEmpty().WithMessage("MEDICAL_RECORD_ID is a required field");

            // Validation rule for 'Audiometry': 
            // Ensures Audiometry must be "Y" or "N" when not null.
            RuleFor(x => x.Audiometry).Must(value => value == "Y" || value == "N").When(value => value!= null).WithMessage("Audiometry must be Y or N");

            // Validation rule for 'PositionChange': 
            // Ensures PositionChange must be "Y" or "N" when not null.
            RuleFor(x => x.PositionChange).Must(value => value == "Y" || value == "N").When(value => value != null).WithMessage("PositionChange must be Y or N");

            // Validation rule for 'MotherData': Ensures that MotherData does not exceed 2000 characters when not null
            RuleFor(x => x.MotherData).MaximumLength(2000).When(value => value != null).WithMessage("MotherData has a maximum of 2000 characters");

            // Validation rule for 'OtherFamilyData': Ensures that OtherFamilyData does not exceed 2000 characters when not null.
            RuleFor(x => x.OtherFamilyData).MaximumLength(2000).When(value => value != null).WithMessage("OtherFamilyData has a maximum of 2000 characters");

            // Validation rule for 'FatherData': Ensures that FatherData does not exceed 2000 characters when not null
            RuleFor(x => x.FatherData).MaximumLength(2000).When(value => value != null).WithMessage("FatherData has a maximum of 2000 characters");

            // Validation rule for 'ExecuteMicros': 
            // Ensures ExecuteMicros must be "Y" or "N" when not null.
            RuleFor(x => x.ExecuteMicros).Must(value => value == "Y" || value == "N").When(value => value != null).WithMessage("ExecuteMicros must be Y or N");

            // Validation rule for 'ExecuteExtra': 
            // Ensures ExecuteExtra must be "Y" or "N" when not null.
            RuleFor(x => x.ExecuteExtra).Must(value => value == "Y" || value == "N").When(value => value != null).WithMessage("ExecuteExtra must be Y or N");

            // Validation rule for 'VoiceEvaluation': 
            // Ensures VoiceEvaluation must be "Y" or "N" when not null.
            RuleFor(x => x.VoiceEvaluation).Must(value => value == "Y" || value == "N").When(value => value != null).WithMessage("VoiceEvaluation must be Y or N");

            // Validation rule for 'CreationDate': Ensures that CreationDate is not null or empty
            RuleFor(x => x.CreationDate).NotNull().NotEmpty().WithMessage("CreationDate is a required field");

            // Validation rule for 'EndDate': Ensures that EndDate is later than StartDate when EndDate is not null
            RuleFor(x => x.EndDate).GreaterThan(x => x.StartDate).When(value => value != null).WithMessage("End_Date Must be later than Start_Date");

            // Validation rule for 'Disability': 
            // Ensures Disability must be "Y" or "N" when not null
            RuleFor(x => x.Disability).Must(value => value == "Y" || value == "N").When(value => value != null).WithMessage("Disability must be Y or N");

            // Validation rule for 'MedicalBoard': Ensures that MedicalBoard does not exceed 200 characters when not null
            RuleFor(x => x.MedicalBoard).MaximumLength(200).When(value => value != null).WithMessage("MedicalBoard has a maximum of 200 characters");

            // Validation rule for 'DeletionReason': Ensures that DeletionReason does not exceed 2000 characters when not null
            RuleFor(x => x.DeletionReason).MaximumLength(2000).When(value => value != null).WithMessage("DeletionReason has a maximum of 2000 characters");

            // Validation rule for 'Observations': Ensures that Observations does not exceed 2000 characters when not null
            RuleFor(x => x.Observations).MaximumLength(2000).When(value => value != null).WithMessage("Observations has a maximum of 2000 characters");
            // Validation rule for 'DisabilityPercentage': Ensures that DisabilityPercentage is between 0 and 100 when Disability is "Y".
            RuleFor(x => x.DisabilityPercentage).InclusiveBetween(0m, 100m).When(x => x.Disability == "Y" && x.DisabilityPercentage != null).WithMessage("DisabilityPercentage must be between 0 and 100");

            // Validation rule for 'AreaChange': 
            // Ensures AreaChange must be "Y" or "N" when not null
            RuleFor(x => x.AreaChange).Must(value => value == "Y" || value == "N").When(value => value != null).WithMessage("AreaChange must be Y or N");


        }
    }
}
