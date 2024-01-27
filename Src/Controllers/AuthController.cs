using AsaBloggerApi.Src.Helpers;
using AsaBloggerApi.Src.Logics;
using AsaBloggerApi.Src.Models.DTO;
using AsaBloggerApi.Src.Utils;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace AsaBloggerApi.Src.Controllers{

[ApiController]
[Route("api/auth")]
    public sealed class AuthController : ControllerBase{
        private readonly AuthLogic _logic ;
        public AuthController(){
          
            _logic = new AuthLogic();
        }

        [HttpPost]
        [Route("signup")]
        public async Task<IActionResult> Signup([FromBody] SignupDTO input)
        {
            try
            {
             
                if(!CommonUtils.AllStringPropertyValuesAreNonEmpty(input)){
                    return BadRequest(ApiHelper.BadPatameters());
                }
                var result =await _logic.Signup(input);

                return Ok(ApiHelper.SendResponse(result));

            }
            catch (Exception ex)
            {
                return BadRequest(ApiHelper.SendError(error:ex.ToString()));
            }
        }
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO input)
        {
            try
            {
                 if(!CommonUtils.AllStringPropertyValuesAreNonEmpty(input)){
                    return BadRequest(ApiHelper.BadPatameters());
                }
                 var result =await _logic.Login(input);

                return Ok(ApiHelper.SendResponse(result));

            }
            catch (Exception ex)
            {
                return BadRequest(ApiHelper.SendError(error:ex.ToString()));
            }
        }
          [Route("checkToken")]
        public async Task<IActionResult> CheckToken([FromBody] CheckTokenDTO input)
        {
            try
            {
                 if(!CommonUtils.AllStringPropertyValuesAreNonEmpty(input)){
                    return BadRequest(ApiHelper.BadPatameters());
                }
                  var result =await _logic.CheckToken(input);

                return Ok(ApiHelper.SendResponse(result));

            }
            catch (Exception ex)
            {
                return BadRequest(ApiHelper.SendError(error:ex.ToString()));
            }
        }

    }
}