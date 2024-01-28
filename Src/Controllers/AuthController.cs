using AsaBloggerApi.Src.Utils;
using AsaBloggerApi.Src.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using AsaBloggerApi.Src.Services.Interfaces;

namespace AsaBloggerApi.Src.Controllers
{

    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
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

            if (!input.IsValid())
            {
                return BadRequest(ApiUtils.BadPatameters());
            }
            var result = await _service.Signup(input);

            return Ok(ApiUtils.SendResponse(result));

        }


        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO input)
        {

            if (!input.IsValid())
            {
                return BadRequest(ApiUtils.BadPatameters());
            }
            var result = await _service.Login(input);
            return Ok(ApiUtils.SendResponse(result));

        }
        [HttpPost]
        [Route("checktoken")]
        public async Task<IActionResult> CheckToken([FromBody] CheckTokenDTO input)
        {

            if (!input.IsValid())
            {
                return BadRequest(ApiUtils.BadPatameters());
            }
            var result = await _service.CheckToken(input);

            return Ok(ApiUtils.SendResponse(result));

        }

    }


}