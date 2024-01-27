using AsaBloggerApi.Src.Models;
using AsaBloggerApi.Src.Models.DTO;

namespace AsaBloggerApi.Src.Services
{
     public interface IBlogService{
        Task<BlogModel> GetBlog(GetBlogDTO input);

    }
}