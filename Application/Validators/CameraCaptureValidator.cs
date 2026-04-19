using AppCore.DTO_s;
using FluentValidation;

namespace AppCore.Validators;

public class CameraCaptureValidator : AbstractValidator<CameraCaptureDto>
{
    public CameraCaptureValidator()
    {
        RuleFor(c => c.LicensePlate)
            .NotEmpty()
            .MaximumLength(10);
        RuleFor(c => c.GateName)
            .NotEmpty()
            .MaximumLength(50);
        RuleFor(c => c.Brand)
            .NotEmpty()
            .MaximumLength(50);
        RuleFor(c => c.Color)
            .NotEmpty();
    }
}