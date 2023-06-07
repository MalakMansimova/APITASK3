using FluentValidation;
using WEB_API.Entities.Dtos.Cars;

namespace WEB_API.Validators.Cars
{
    public class CreateCarDtoValidator : AbstractValidator<CreateCarDto>
    {
        public CreateCarDtoValidator()
        {
            RuleFor(p => p.DailyPrice)
                                     .NotNull()
                                     .GreaterThanOrEqualTo(100)
                                     .LessThanOrEqualTo(50000);

            RuleFor(p => p.Description)
                                    .NotEmpty()
                                    .NotNull()
                                    .MaximumLength(100)
                                    .MinimumLength(3);
        }
    }
}
