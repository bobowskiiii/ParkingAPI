using AppCore.DTO_s.Gate;
using Domain.Enums;
using FluentValidation;

namespace AppCore.Validators;

public class ParkingGateValidator : AbstractValidator<CreateGateDto>
{
    public ParkingGateValidator()
    {
        RuleFor(g => g.Name)
            .NotEmpty()
            .MaximumLength(50)
            .Matches(@"^[\p{L}\s\-]+$").WithMessage("Name must contain only letters, spaces, hyphens and apostrophes.");

        RuleFor(g => g.Location)
            .NotEmpty().WithMessage("Location is required")
            .MaximumLength(50).WithMessage("Location must be at most 50 characters long");
        
        RuleFor(x => x.Type)
            .NotEmpty().WithMessage("Type is required")
            .Must(type => Enum.TryParse<GateType>(type, true, out _))
            .WithMessage($"Typ bramki musi być jedną z wartości: {string.Join(", ", Enum.GetNames<GateType>())}.");
    }
}