using AsaBloggerApi.Src.Models;
using AsaBloggerApi.Src.Models.DTO;
using AsaBloggerApi.Src.Repositories;

namespace AsaBloggerApi.Src.Logics
{
    public sealed class AuthLogic
    {
        private readonly Repository _repository;

        public AuthLogic()
        {
            _repository = Repository.GetRepository();
        }
        public async Task<UserModel> Signup(SignupDTO input)
        {
            return null;
        }
        public async Task<UserModel> Login(LoginDTO input)
        {
            return null;
        }
        public async Task<UserModel> CheckToken(CheckTokenDTO input)
        {
            return null;
        }
    }
}
