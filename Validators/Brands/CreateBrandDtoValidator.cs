using FluentValidation;
using WEB_API.Entities.Dtos.Brand;

namespace WEB_API.Validators.Brands
{
    public class CreateBrandDtoValidator : AbstractValidator<CreateBrandDto>
    {
        public CreateBrandDtoValidator()
        {
            RuleFor(p => p.Name).NotEmpty()
                              .NotNull()
                              .MaximumLength(50)
                              .MinimumLength(3);
        }
    }
}
