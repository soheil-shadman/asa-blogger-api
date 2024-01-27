using AsaBloggerApi.Src.Models;
using AsaBloggerApi.Src.Models.DTO;

namespace AsaBloggerApi.Src.Services
{
    public interface IAuthService{
        Task<UserModel> Signup(SignupDTO input);
        Task<UserModel> Login(LoginDTO input);
        Task<UserModel> CheckToken(CheckTokenDTO input);
    }
}