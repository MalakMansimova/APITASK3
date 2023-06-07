using FluentValidation;
using System.Reflection;
using WEB_API.Entities.Dtos.Colors;

namespace WEB_API.Validators.Colors
{
    public class CreateColorDtoValidator : AbstractValidator<CreateColorDto>
    {
        public CreateColorDtoValidator()
        {
            RuleFor(p => p.Name).NotEmpty()
                                .NotNull()
                                .MaximumLength(50)
                                .MinimumLength(3); 

        }
    }
}
