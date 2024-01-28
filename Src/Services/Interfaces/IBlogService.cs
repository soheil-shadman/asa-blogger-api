using AsaBloggerApi.Src.Models;
using AsaBloggerApi.Src.Models.DTO;

namespace AsaBloggerApi.Src.Services.Interfaces
{
    public interface IBlogService
    {
        Task<BlogModel> GetBlog(GetBlogDTO input);
        Task<BlogModel> CreateBlog(CreateBlogDTO input);
        Task<List<BlogModel>> GetBlogs();
        Task<CommentModel> CreateComment(CreateCommentDTO input);
        Task<List<CommentModel>> GetUserComments(GetUserCommentsDTO input);
        Task<List<CommentModel>> GetBlogComments(GetBlogCommentsDTO input);
        Task<BlogModel> EditBlog(EditBlogDTO input);
        Task<CommentModel> EditComment(EditCommentDTO input);


    }
}