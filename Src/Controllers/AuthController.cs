using AsaBloggerApi.Src.Utils;
using AsaBloggerApi.Src.Services;
using AsaBloggerApi.Src.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace AsaBloggerApi.Src.Controllers
{

    [ApiController]
    [Route("api/auth")]
    public sealed class AuthController : ControllerBase
    {
        private readonly IAuthService _service;
        public AuthController(IAuthService service)
        {

            _service = service;
        }

        [HttpPost]
        [Route("signup")]
        public async Task<IActionResult> Signup([FromBody] SignupDTO input)
        {
            try
            {

                if (!CommonUtils.AllStringPropertyValuesAreNonEmpty(input))
                {
                    return BadRequest(ApiUtils.BadPatameters());
                }
                var result = await _service.Signup(input);

                return Ok(ApiUtils.SendResponse(result));

            }
            catch (Exception ex)
            {
                return BadRequest(ApiUtils.SendError(error: ex.ToString()));
            }
        }
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO input)
        {
            try
            {
                if (!CommonUtils.AllStringPropertyValuesAreNonEmpty(input))
                {
                    return BadRequest(ApiUtils.BadPatameters());
                }
                var result = await _service.Login(input);

                return Ok(ApiUtils.SendResponse(result));

            }
            catch (Exception ex)
            {
                return BadRequest(ApiUtils.SendError(error: ex.ToString()));
            }
        }
        [HttpPost]
        [Route("checkToken")]
        public async Task<IActionResult> CheckToken([FromBody] CheckTokenDTO input)
        {
            try
            {
                if (!CommonUtils.AllStringPropertyValuesAreNonEmpty(input))
                {
                    return BadRequest(ApiUtils.BadPatameters());
                }
                var result = await _service.CheckToken(input);

                return Ok(ApiUtils.SendResponse(result));

            }
            catch (Exception ex)
            {
                return BadRequest(ApiUtils.SendError(error: ex.ToString()));
            }
        }

    }
}