using AsaBloggerApi.Src.Logics;
using AsaBloggerApi.Src.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace AsaBloggerApi.Src.Controllers{

[ApiController]
[Route("api/blog")]
    public sealed class BlogController : ControllerBase{
        private readonly BlogLogic _logic ;
        public BlogController(){
          
            _logic = new BlogLogic();
        }

        [HttpGet]
        [Route("getBlog")]
        public IActionResult GetBlog()
        {
            try
            {
                  Console.WriteLine("annn");
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