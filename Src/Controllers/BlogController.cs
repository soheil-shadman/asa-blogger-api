using AsaBloggerApi.Src.Models.DTO;
using AsaBloggerApi.Src.Services;
using Microsoft.AspNetCore.Mvc;

namespace AsaBloggerApi.Src.Controllers
{

    [ApiController]
    [Route("api/blog")]
    public sealed class BlogController : ControllerBase
    {
        private readonly IBlogService _service;
        public BlogController(IBlogService service)
        {

            _service = service;
        }

        [HttpGet]
        [Route("getBlog")]
        public IActionResult GetBlog()
        {
            try
            {

                //   [FromBody] SignupDTO input
                return Ok("Ola");

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

    }
}