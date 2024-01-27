using AsaBloggerApi.Src.Models;
using AsaBloggerApi.Src.Models.DTO;

namespace AsaBloggerApi.Src.Services.Interfaces
{
     public interface IBlogService{
        Task<BlogModel> GetBlog(GetBlogDTO input);

    }
}