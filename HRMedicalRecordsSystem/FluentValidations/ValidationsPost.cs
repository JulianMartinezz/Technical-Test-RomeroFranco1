using FluentValidation;
using HRMedicalRecordsSystem.DTOs;

namespace HRMedicalRecordsSystem.FluentValidations
{
    public class ValidationsPost : AbstractValidator<MedicalPostDTO>
    {
        public ValidationsPost() 
        {
            RuleFor(x => x.diagnosis).NotNull().MaximumLength(100).WithMessage("Diagnosis has a maximum of 100 characters");

            RuleFor(x => x.StartDate).LessThan(x => x.EndDate).WithMessage("START_DATE cannot be later than END_DATE");

            RuleFor(x => x.StatusId).InclusiveBetween(1, 2).NotNull().WithMessage("Status_ID must exist");

            RuleFor(x => x.MedicalRecordTypeId).InclusiveBetween(1, 2).NotNull().WithMessage("MEDICAL_RECORD_TYPE_ID must exist");

            RuleFor(x => x.FileId).NotNull().NotEmpty().WithMessage("FILE_ID is a required field");

            RuleFor(x => x.CreatedBy).NotNull().WithMessage("CREATED_BY is a required field");

            RuleFor(x => x.MedicalRecordId).NotNull().NotEmpty().WithMessage("MEDICAL_RECORD_ID is a required field");

            RuleFor(x => x.Audiometry).Must(value => value == "Y" || value == "N").When(value => value!= null).WithMessage("Audiometry must be YES or NO");

            RuleFor(x => x.PositionChange).Must(value => value == "Y" || value == "N").When(value => value != null).WithMessage("PositionChange must be YES or NO");

            RuleFor(x => x.MotherData).MaximumLength(2000).When(value => value != null).WithMessage("MotherData has a maximum of 2000 characters");

            RuleFor(x => x.OtherFamilyData).MaximumLength(2000).When(value => value != null).WithMessage("OtherFamilyData has a maximum of 2000 characters");

            RuleFor(x => x.FatherData).MaximumLength(2000).When(value => value != null).WithMessage("FatherData has a maximum of 2000 characters");

            RuleFor(x => x.ExecuteMicros).Must(value => value == "Y" || value == "N").When(value => value != null).WithMessage("ExecuteMicros must be YES or NO");

            RuleFor(x => x.ExecuteExtra).Must(value => value == "Y" || value == "N").When(value => value != null).WithMessage("ExecuteExtra must be YES or NO");

            RuleFor(x => x.VoiceEvaluation).Must(value => value == "Y" || value == "N").When(value => value != null).WithMessage("VoiceEvaluation must be YES or NO");

            RuleFor(x => x.CreationDate).NotNull().NotEmpty().WithMessage("CreationDate is a required field");

            RuleFor(x => x.EndDate).GreaterThan(x => x.StartDate).When(value => value != null).WithMessage("End_Date Must be later than Start_Date");

            RuleFor(x => x.Disability).Must(value => value == "Y" || value == "N").When(value => value != null).WithMessage("Disability must be YES or NO");

            RuleFor(x => x.MedicalBoard).MaximumLength(200).When(value => value != null).WithMessage("MedicalBoard has a maximum of 200 characters");

            RuleFor(x => x.DeletionReason).MaximumLength(2000).When(value => value != null).WithMessage("DeletionReason has a maximum of 2000 characters");

            RuleFor(x => x.Observations).MaximumLength(2000).When(value => value != null).WithMessage("Observations has a maximum of 2000 characters");

            RuleFor(x => x.DisabilityPercentage).InclusiveBetween(0m, 100m).When(x => x.Disability == "YES" && x.DisabilityPercentage != null).WithMessage("DisabilityPercentage must be between 0 and 100");

            RuleFor(x => x.AreaChange).Must(value => value == "Y" || value == "N").When(value => value != null).WithMessage("AreaChange must be YES or NO");










        }
    }
}
