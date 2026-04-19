using AppCore.DTO_s.Gate;
using Domain.Enums;
using FluentValidation;

namespace AppCore.Validators;

public class UpdateGateValidator : AbstractValidator<UpdateGateDto>
{
    public UpdateGateValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Nazwa bramki jest wymagana.")
            .MaximumLength(20).WithMessage("Nazwa nie może przekraczać 20 znaków.")
            .Matches(@"^[\p{L}\s\-]+$").WithMessage("Nazwa zawiera niedozwolone znaki.");

        RuleFor(x => x.Type)
            .NotEmpty().WithMessage("Typ bramki jest wymagany.")
            .Must(type => Enum.TryParse<GateType>(type, true, out _))
            .WithMessage($"Typ bramki musi być jedną z wartości: {string.Join(", ", Enum.GetNames<GateType>())}.");
    }
}

