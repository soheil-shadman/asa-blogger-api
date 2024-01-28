using AsaBloggerApi.Src.Helpers;
using AsaBloggerApi.Src.Infostructure.Interfaces;
using AsaBloggerApi.Src.Models;
using AsaBloggerApi.Src.Models.DTO;
using AsaBloggerApi.Src.Services.Interfaces;
namespace AsaBloggerApi.Src.Services
{
    public class AuthService : IAuthService
    {
          private readonly IRepository _repository;

        public AuthService(IRepository repository)
        {
            _repository = repository;
        }
        public async Task<UserModel> Signup(SignupDTO input)
        {
            var userModel = new UserModel
            {
                Username = input.Username,
                Password = input.Password,
                Email = input.Email
            };
            var targetUser =  await _repository.GetUserByEmailOrUsername(userModel);
            if(targetUser!=null){
                throw new Exception("user already exists");
            }
            userModel = await _repository.CreateUser(userModel);
            return userModel;
        }
        public async Task<UserModel> Login(LoginDTO input)
        {
            var userModel = new UserModel
            {
                Username = input.Username,
                Password = input.Password
            };
            var targetUser = await _repository.GetUserByUsernameAndPassword(userModel) ?? throw new Exception("user not found");
            userModel.LastLogin=DateTime.Now;
            userModel.Id=targetUser.Id;
            userModel.Token=JwtUtils.GenerateJSONWebToken(userModel,Config.GetConfig());
            targetUser = await _repository.SaveUserToken(userModel);
            return targetUser;
        }
        public async Task<UserModel> CheckToken(CheckTokenDTO input)
        {

            var result =JwtUtils.ValidateToken(input.Token,Config.GetConfig());

            if (result==null){
                 throw new Exception("invalid token");
            }
            var userModel= new UserModel{
            Id= (int)result
            };
            userModel = await _repository.GetUserById(userModel);
            if(userModel==null){
                throw new Exception("user not found");
            }
            return userModel;
        }
    }
}
