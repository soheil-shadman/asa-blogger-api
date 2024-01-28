using AsaBloggerApi.Src.Inftastructure.Interfaces;
using AsaBloggerApi.Src.Models;
using AsaBloggerApi.Src.Models.DTO;
using AsaBloggerApi.Src.Services.Interfaces;
namespace AsaBloggerApi.Src.Services
{
    public class BlogService : IBlogService
    {
        private readonly IRepository _repository;

        public BlogService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<BlogModel> CreateBlog(CreateBlogDTO input)
        {
            var blogModel = new BlogModel
            {
                Content = input.Content,
                UserId = int.Parse(input.UserId),
                ImageURL = input.ImageURL,
            };
            var userModel = new UserModel
            {
                Id = int.Parse(input.UserId),
            };
            var targetUser = await _repository.GetUserById(userModel) ?? throw new Exception("user not found");
            blogModel = await _repository.CreateBlog(blogModel);
            return blogModel;
        }

        public async Task<CommentModel> CreateComment(CreateCommentDTO input)
        {
            var blogModel = new BlogModel
            {
                Id = int.Parse(input.BlogId),

            };
            var userModel = new UserModel
            {
                Id = int.Parse(input.UserId),
            };
            var commentModel = new CommentModel
            {
                UserId = int.Parse(input.UserId),
                BlogId = int.Parse(input.BlogId),
                Content = input.Content
            };
            var targetUser = await _repository.GetUserById(userModel) ?? throw new Exception("user not found");
            var targetBlog = await _repository.GetBlogById(blogModel) ?? throw new Exception("blog not found");
            commentModel = await _repository.CreateComment(commentModel);
            return commentModel;
        }

        public async Task<BlogModel> GetBlog(GetBlogDTO input)
        {
            var blogModel = new BlogModel
            {
                Id = int.Parse(input.Id),

            };
            var targetBlog = await _repository.GetBlogById(blogModel) ?? throw new Exception("blog not found");

            return targetBlog;
        }
        public async Task<List<BlogModel>> GetBlogs()
        {
            var targetBlogs = await _repository.GetBlogs();
            return targetBlogs;
        }

        public async Task<List<CommentModel>> GetBlogComments(GetBlogCommentsDTO input)
        {
            var blogModel = new BlogModel
            {
                Id = int.Parse(input.BlogId),

            };
            var targetBlog = await _repository.GetBlogById(blogModel) ?? throw new Exception("blog not found");
            var comments = await _repository.GetCommentsByBlogId(blogModel);
            return comments;

        }

        public async Task<List<CommentModel>> GetUserComments(GetUserCommentsDTO input)
        {
            var userModel = new UserModel
            {
                Id = int.Parse(input.UserId),

            };
            var targetUser = await _repository.GetUserById(userModel) ?? throw new Exception("user not found");
            var comments = await _repository.GetCommentsByUserId(userModel);
            return comments;
        }

        public async Task<BlogModel> EditBlog(EditBlogDTO input)
        {
             var blogModel = new BlogModel
            {
                Id = int.Parse(input.Id),
                Content = input.Content
            };
    
            blogModel = await _repository.EditBlog(blogModel);
            if(blogModel==null){
                throw new Exception("blog not found");
            }
            return blogModel;
        }

        public async Task<CommentModel> EditComment(EditCommentDTO input)
        {
              var commentModel = new CommentModel
            {
                Id = int.Parse(input.Id),
                Content = input.Content
            };
    
            commentModel = await _repository.EditComment(commentModel);
            if(commentModel==null){
                throw new Exception("comment not found");
            }
            return commentModel;
        }
    }
}
