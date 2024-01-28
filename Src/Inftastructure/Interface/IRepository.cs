using AsaBloggerApi.Src.Models;

namespace AsaBloggerApi.Src.Inftastructure.Interfaces
{
    public interface IRepository
    {
        Task<UserModel> CreateUser(UserModel userModel);
        Task<BlogModel> CreateBlog(BlogModel blogModel);
        Task<CommentModel> CreateComment(CommentModel commentModel);

        Task<UserModel> SaveUserToken(UserModel userModel);

        Task<UserModel?> GetUserById(UserModel userModel);

        Task<UserModel?> GetUserByEmailAndUsername(UserModel userModel);

        Task<UserModel?> GetUserByUsernameAndPassword(UserModel userModel);

        Task<UserModel?> GetUserByEmailOrUsername(UserModel userModel);
        Task<BlogModel?> GetBlogById(BlogModel blogModel);
        Task<List<BlogModel>> GetBlogs();

        Task<List<CommentModel>> GetCommentsByBlogId(BlogModel blogModel);
        Task<List<CommentModel>> GetCommentsByUserId(UserModel userModel);
        Task<BlogModel?> EditBlog(BlogModel blogModel);
        Task<CommentModel?> EditComment(CommentModel commentModel);


    }
}