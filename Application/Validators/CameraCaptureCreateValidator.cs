using AppCore.DTO_s;
using Domain.Enums;
using FluentValidation;

namespace AppCore.Validators;

public class CameraCaptureCreateValidator : AbstractValidator<CameraCaptureCreateDto>
{
    public CameraCaptureCreateValidator()
    {
        RuleFor(c => c.LicensePlate)
            .NotEmpty().WithMessage("Numer rejestracyjny jest wymagany.")
            .MaximumLength(10).WithMessage("Numer rejestracyjny nie może przekraczać 10 znaków.");
        RuleFor(x => x.DetectedBrand)
            .NotEmpty().WithMessage("Nazwa marki jest wymagana.");
        RuleFor(x => x.DetectedColor)
            .NotEmpty().WithMessage("Nazwa koloru jest wymagana.");
        RuleFor(x => x.ImagePath)
            .NotEmpty().WithMessage("Ścieżka do zdjęcia jest wymagana.");
        RuleFor(x => x.CaptureType)
            .NotEmpty()
            .Must(t => Enum.TryParse<CaptureType>(t, true, out _))
            .WithMessage($"Typ przechwytywania musi być jedną z wartości: {string.Join(", ", Enum.GetNames<CaptureType>())}.");
    }
}