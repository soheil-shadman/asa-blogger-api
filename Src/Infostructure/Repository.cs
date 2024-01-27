using AsaBloggerApi.Src.Domain.Entities;
using AsaBloggerApi.Src.Models;
using AsaBloggerApi.Src.Repositories;
using Microsoft.EntityFrameworkCore;
namespace AsaBloggerApi.Src.Infostructure
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

            _context.Update(query);
            await _context.SaveChangesAsync();
            return userModel;
        }

        public async Task<UserModel?> GetUserByToken(UserModel userModel)
        {

            var query = await _context.Users.Where(d => d.Token.Equals(userModel.Token)).FirstOrDefaultAsync();
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
    }

}

