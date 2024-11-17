using LocalizationExample.Api.Models;
using LocalizationExample.Api.Validators;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace LocalizationExample.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        internal readonly IStringLocalizer<UserController> _localizer;
        internal readonly UserValidator _validator;

        public UserController(IStringLocalizer<UserController> localizer, UserValidator validator)
        {
            _localizer = localizer;
            _validator = validator;
        }

        [HttpPost]
        public async Task<IActionResult> SignUpAsync(UserRequestModel requestModel)
        {
            var validationResult = await _validator.ValidateAsync(requestModel);
            if (!validationResult.IsValid)
            {
                string error = _localizer["UserNameNotEmpty"].Value;
                string errors = string.Join(" ", validationResult.Errors.Select(x => x.ErrorMessage));
                return BadRequest(errors);
            }
            return Ok();
        }
    }
}
