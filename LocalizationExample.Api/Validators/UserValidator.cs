namespace LocalizationExample.Api.Validators;

public class UserValidator : AbstractValidator<UserRequestModel>
{
    private readonly IStringLocalizer<UserController> _localizer;

    public UserValidator(IStringLocalizer<UserController> localizer)
    {
        _localizer = localizer;
        RuleFor(x => x.UserName)
            .NotEmpty()
            .WithMessage(_localizer["UserNameNotEmpty"].Value)
            .NotNull()
            .WithMessage(_localizer["UserNameNotEmpty"].Value);
        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage(_localizer["EmailNotEmpty"].Value)
            .NotNull()
            .WithMessage(_localizer["EmailNotEmpty"].Value);
    }
}
