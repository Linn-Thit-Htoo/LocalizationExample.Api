using LocalizationExample.Api.Models;
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

        public UserController(IStringLocalizer<UserController> localizer)
        {
            _localizer = localizer;
        }

        [HttpPost]
        public IActionResult SignUp(UserRequestModel requestModel)
        {
            if (string.IsNullOrEmpty(requestModel.UserName))
            {
                string errorMessage = _localizer["UserName"].Value;
                return BadRequest(errorMessage);
            }

            return Ok();
        }
    }
}
