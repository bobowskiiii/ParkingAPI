using AppCore.DTO_s.Tarrif;
using FluentValidation;

namespace AppCore.Validators;

public class CreateTariffValidator :AbstractValidator<CreateTariffDto>
{
    public CreateTariffValidator()
    {
        RuleFor(t => t.Name)
            .NotEmpty()
            .MaximumLength(50);
        
        RuleFor(t => t.FreeMinutes)
            .GreaterThanOrEqualTo(0).WithMessage("Free minutes must be greater than or equal to 0");
        RuleFor(t => t.HourlyRate)
            .GreaterThanOrEqualTo(0).WithMessage("Hourly rate must be greater than or equal to 0");
        RuleFor(t => t.DailyMaxRate)
            .GreaterThanOrEqualTo(0).WithMessage("Daily max rate must be greater than or equal to 0");
    }
}