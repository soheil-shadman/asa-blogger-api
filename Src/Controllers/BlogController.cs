
using AsaBloggerApi.Src.Models;
using AsaBloggerApi.Src.Models.DTO;
using AsaBloggerApi.Src.Services.Interfaces;
using AsaBloggerApi.Src.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AsaBloggerApi.Src.Controllers
{

    [ApiController]
    [Route("api/blog")]
    public class BlogController : ControllerBase
    {
        private readonly IBlogService _service;
        private readonly HttpContext _context;
        public BlogController(IBlogService service)
        {

            _service = service;
            _context=HttpContext;
        }

        [HttpPost]
        [Authorize]
        [Route("createblog")]
        public async Task<IActionResult> CreateBlog([FromBody] CreateBlogDTO input)
        {
            var userModel = (UserModel)_context.Items["User"];
            if (userModel==null||userModel.Id != int.Parse(input.UserId))
            {
                return BadRequest(ApiUtils.AccessDenied());
            }

            if (!input.IsValid())
            {
                return BadRequest(ApiUtils.BadPatameters());
            }
            var result = await _service.CreateBlog(input);

            return Ok(ApiUtils.SendResponse(result));

        }
        [HttpPost]
        [Authorize]
        [Route("createcomment")]
        public async Task<IActionResult> CreateComment([FromBody] CreateCommentDTO input)
        {   
            var userModel = (UserModel)_context.Items["User"];
            if (userModel==null||userModel.Id != int.Parse(input.UserId))
            {
                return BadRequest(ApiUtils.AccessDenied());
            }

            if (!input.IsValid())
            {
                return BadRequest(ApiUtils.BadPatameters());
            }
            var result = await _service.CreateComment(input);

            return Ok(ApiUtils.SendResponse(result));

        }

        [HttpGet]
        [Route("getblogs")]
        public async Task<IActionResult> GetBlogs()
        {

            var result = await _service.GetBlogs();

            return Ok(ApiUtils.SendResponse(result));

        }
        [HttpGet]
        [Route("getblog")]
        public async Task<IActionResult> GetBlog([FromQuery] GetBlogDTO input)
        {

            if (!input.IsValid())
            {
                return BadRequest(ApiUtils.BadPatameters());
            }
            var result = await _service.GetBlog(input);

            return Ok(ApiUtils.SendResponse(result));

        }

        [HttpGet]
        [Route("getusercomments")]
        public async Task<IActionResult> GetComments([FromQuery] GetUserCommentsDTO input)
        {

            if (!input.IsValid())
            {
                return BadRequest(ApiUtils.BadPatameters());
            }
            var result = await _service.GetUserComments(input);

            return Ok(ApiUtils.SendResponse(result));

        }
        [HttpGet]
        [Route("getblogcomments")]
        public async Task<IActionResult> GetBlogComments([FromQuery] GetBlogCommentsDTO input)
        {

            if (!input.IsValid())
            {
                return BadRequest(ApiUtils.BadPatameters());
            }
            var result = await _service.GetBlogComments(input);

            return Ok(ApiUtils.SendResponse(result));

        }
        [HttpPatch]
        [Authorize]
        [Route("editblog")]
        public async Task<IActionResult> EditBlog([FromBody] EditBlogDTO input)
        {
            var userModel = (UserModel)_context.Items["User"];
            if (userModel==null||userModel.Id != int.Parse(input.UserId))
            {
                return BadRequest(ApiUtils.AccessDenied());
            }
            if (!input.IsValid())
            {
                return BadRequest(ApiUtils.BadPatameters());
            }
            var result = await _service.EditBlog(input);

            return Ok(ApiUtils.SendResponse(result));

        }
        [HttpPatch]
        [Authorize]
        [Route("editcomment")]
        public async Task<IActionResult> EditComment([FromBody] EditCommentDTO input)
        {
            var context = HttpContext;
            var userModel = (UserModel)context.Items["User"];
            if (userModel==null||userModel.Id != int.Parse(input.UserId))
            {
                return BadRequest(ApiUtils.AccessDenied());
            }

            if (!input.IsValid())
            {
                return BadRequest(ApiUtils.BadPatameters());
            }
            var result = await _service.EditComment(input);

            return Ok(ApiUtils.SendResponse(result));

        }



    }
}