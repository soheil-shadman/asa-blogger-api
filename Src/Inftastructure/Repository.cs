using AsaBloggerApi.Src.Domain.Entities;
using AsaBloggerApi.Src.Inftastructure.Interfaces;
using AsaBloggerApi.Src.Models;

using Microsoft.EntityFrameworkCore;
namespace AsaBloggerApi.Src.Inftastructure
{
    public class Repository : IRepository
    {
        private readonly EFDataContext _context;
        public Repository(EFDataContext context)
        {
            _context = context;
        }

        public async Task<UserModel> CreateUser(UserModel userModel)
        {
            var userEntity = new UserEntity()
            {
                Email = userModel.Email,
                Password = userModel.Password,
                Username = userModel.Username
            };
            await _context.Users.AddAsync(userEntity);
            await _context.SaveChangesAsync();
            return new UserModel()
            {
                Id = userEntity.Id,
                Username = userEntity.Username,
                Password = userEntity.Password,
                Email = userEntity.Email,
            };
        }

        public async Task<UserModel> SaveUserToken(UserModel userModel)
        {

            var query = await _context.Users.Where(d => d.Id.Equals(userModel.Id)).FirstOrDefaultAsync();
            query.Token = userModel.Token;
            query.LastLogin = userModel.LastLogin;
            query.UpdateAt = DateTime.Now;
            _context.Update(query);
            await _context.SaveChangesAsync();
            return userModel;
        }

        public async Task<UserModel?> GetUserById(UserModel userModel)
        {

            var query = await _context.Users.Where(d => d.Id.Equals(userModel.Id)).FirstOrDefaultAsync();
            if (query == null)
            {
                return null;
            }
            return new UserModel()
            {
                Id = query.Id,
                Username = query.Username,
                Password = query.Password,
                Email = query.Email,
                Token = query.Token,
                LastLogin = query.LastLogin,
                NumberOfBlogs = query.NumberOfBlogs
            };
        }
        public async Task<UserModel?> GetUserByEmailAndUsername(UserModel userModel)
        {

            var query = await _context.Users.Where(d => d.Username.Equals(userModel.Username) && d.Password.Equals(userModel.Password)).FirstOrDefaultAsync();
            if (query == null)
            {
                return null;
            }
            return new UserModel()
            {
                Id = query.Id,
                Username = query.Username,
                Password = query.Password,
                Email = query.Email,
                Token = query.Token,
                LastLogin = query.LastLogin,
                NumberOfBlogs = query.NumberOfBlogs
            };
        }
        public async Task<UserModel?> GetUserByUsernameAndPassword(UserModel userModel)
        {


            var query = await _context.Users.Where(d => d.Username.Equals(userModel.Username) && d.Password.Equals(userModel.Password)).FirstOrDefaultAsync();
            if (query == null)
            {
                return null;
            }
            return new UserModel()
            {
                Id = query.Id,
                Username = query.Username,
                Password = query.Password,
                Email = query.Email,
                Token = query.Token,
                LastLogin = query.LastLogin,
                NumberOfBlogs = query.NumberOfBlogs
            };
        }
        public async Task<UserModel?> GetUserByEmailOrUsername(UserModel userModel)
        {

            var query = await _context.Users.Where(d => d.Username.Equals(userModel.Username) || d.Email.Equals(userModel.Email)).FirstOrDefaultAsync();
            if (query == null)
            {
                return null;
            }
            return new UserModel()
            {
                Id = query.Id,
                Username = query.Username,
                Password = query.Password,
                Email = query.Email,
                Token = query.Token,
                LastLogin = query.LastLogin,
                NumberOfBlogs = query.NumberOfBlogs
            };
        }

        public async Task<BlogModel> CreateBlog(BlogModel blogModel)
        {
            var entity = new BlogEntity()
            {
                Content = blogModel.Content,
                ImageURL = blogModel.ImageURL,
                UserId = blogModel.UserId
            };
            await _context.Blogs.AddAsync(entity);
            await _context.SaveChangesAsync();
            return new BlogModel()
            {
                Id = entity.Id,
                Content = entity.Content,
                ImageURL = entity.ImageURL,
                PublishedDate = entity.PublishedDate,
                UserId = entity.UserId
            };
        }

        public async Task<CommentModel> CreateComment(CommentModel commentModel)
        {
            var entity = new CommentEntity()
            {
                Content = commentModel.Content,
                BlogId = commentModel.BlogId,
                UserId = commentModel.UserId
            };
            await _context.Comments.AddAsync(entity);
            await _context.SaveChangesAsync();
            return new CommentModel()
            {
                Id = entity.Id,
                Content = entity.Content,
                BlogId = entity.BlogId,
                UserId = entity.UserId,
                PublishedDate = entity.PublishedDate,
            };
        }


        public async Task<BlogModel?> GetBlogById(BlogModel blogModel)
        {
            var query = await _context.Blogs.Where(d => d.Id.Equals(blogModel.Id)).FirstOrDefaultAsync();
            if (query == null)
            {
                return null;
            }
            return new BlogModel()
            {
                Id = query.Id,
                Content = query.Content,
                ImageURL = query.ImageURL,
                PublishedDate = query.PublishedDate,
                UserId = query.UserId
            };
        }

        public async Task<List<BlogModel>> GetBlogs()
        {
            var blogEntities = await _context.Blogs.ToListAsync();
            if (blogEntities.Count == 0)
            {
                return [];
            }
            List<BlogModel> items = [];
            foreach (BlogEntity element in blogEntities)
            {
                items.Add(new BlogModel()
                {
                    Id = element.Id,
                    Content = element.Content,
                    ImageURL = element.ImageURL,
                    PublishedDate = element.PublishedDate,
                    UserId = element.UserId
                });
            }
            return items;
        }

        public async Task<List<CommentModel>> GetCommentsByBlogId(BlogModel blogModel)
        {
            var commentEntities = await _context.Comments.Where(d => d.BlogId.Equals(blogModel.Id)).ToListAsync();
            if (commentEntities.Count == 0)
            {
                return [];
            }
            List<CommentModel> items = [];
            foreach (CommentEntity element in commentEntities)
            {
                items.Add(new CommentModel()
                {
                    Id = element.Id,
                    Content = element.Content,
                    BlogId = element.BlogId,
                    UserId = element.UserId,
                    PublishedDate = element.PublishedDate,
                });
            }
            return items;
        }

        public async Task<List<CommentModel>> GetCommentsByUserId(UserModel userModel)
        {
            var commentEntities = await _context.Comments.Where(d => d.UserId.Equals(userModel.Id)).ToListAsync();
            if (commentEntities.Count == 0)
            {
                return [];
            }
            List<CommentModel> items = [];
            foreach (CommentEntity element in commentEntities)
            {
                items.Add(new CommentModel()
                {
                    Id = element.Id,
                    Content = element.Content,
                    BlogId = element.BlogId,
                    UserId = element.UserId,
                    PublishedDate = element.PublishedDate,
                });
            }
            return items;
        }

        public async Task<BlogModel?> EditBlog(BlogModel blogModel)
        {
            var query = await _context.Blogs.Where(d => d.Id.Equals(blogModel.Id)).FirstOrDefaultAsync();
            if (query == null)
            {
                return null;
            }
            query.Content = blogModel.Content;
            query.UpdateAt = DateTime.Now;
            _context.Update(query);
            await _context.SaveChangesAsync();
            return new BlogModel()
            {
                Id = query.Id,
                Content = query.Content,
                ImageURL = query.ImageURL,
                PublishedDate = query.PublishedDate,
                UserId = query.UserId
            };
        }


        public async Task<CommentModel?> EditComment(CommentModel commentModel)
        {
            var query = await _context.Comments.Where(d => d.Id.Equals(commentModel.Id)).FirstOrDefaultAsync();
            if (query == null)
            {
                return null;
            }
            query.Content = commentModel.Content;
            query.UpdateAt = DateTime.Now;
            _context.Update(query);
            await _context.SaveChangesAsync();
            return new CommentModel()
            {
                Id = query.Id,
                Content = query.Content,
                BlogId = query.BlogId,
                UserId = query.UserId,
                PublishedDate = query.PublishedDate,
            };
        }
    }

}

