using AsaBloggerApi.Src.Models;

namespace AsaBloggerApi.Src.Repositories{
    public interface IRepository{
        Task<UserModel> CreateUser(UserModel userModel);
     
       Task<UserModel> SaveUserToken(UserModel userModel);
      

       Task<UserModel?> GetUserByToken(UserModel userModel);
       
        Task<UserModel?> GetUserByEmailAndUsername(UserModel userModel);
      
        Task<UserModel?> GetUserByUsernameAndPassword(UserModel userModel);
      
        Task<UserModel?> GetUserByEmailOrUsername(UserModel userModel);
      
    }
}