using AsaBloggerApi.Src.Helpers;
using AsaBloggerApi.Src.Infostructure.Interfaces;
using AsaBloggerApi.Src.Models;

namespace AsaBloggerApi.Src.Middlewares
{
    public class AuthMiddleWare
    {
        private readonly RequestDelegate _next;

        public AuthMiddleWare(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IRepository repository)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var userId = JwtUtils.ValidateToken(token,Config.GetConfig());
            if (userId != null)
            {
                
                context.Items["User"] = repository.GetUserById(new UserModel(){
                    Id=(int)userId
                });
            }

            await _next(context);
        }
    }
}