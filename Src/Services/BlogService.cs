using AsaBloggerApi.Src.Models;
using AsaBloggerApi.Src.Models.DTO;
using AsaBloggerApi.Src.Repositories;
using AsaBloggerApi.Src.Services.Interfaces;
namespace AsaBloggerApi.Src.Services{
    public class BlogService : IBlogService{
    private readonly IRepository _repository;

    public BlogService(IRepository repository){
        _repository =repository;
    }

        public async Task<BlogModel> GetBlog(GetBlogDTO input)
        {
     
            return null;
        }
}
}
