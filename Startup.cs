using System.Text;
using AsaBloggerApi.Src.Infostructure;
using AsaBloggerApi.Src.Infostructure.Interfaces;
using AsaBloggerApi.Src.Middlewares;
using AsaBloggerApi.Src.Services;
using AsaBloggerApi.Src.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
public class Startup
{
    public IConfiguration configRoot
    {
        get;
    }
    public Startup(IConfiguration configuration)
    {
        configRoot = configuration;
    }
    public void ConfigureServices(IServiceCollection services)
    {

        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddDbContext<EFDataContext>(o => o.UseNpgsql(configRoot.GetConnectionString("BLOG_DB")));
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IBlogService, BlogService>();
        services.AddTransient<IRepository, Repository>();
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
                    {

                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuer = false,
                            ValidateAudience = false,
                            ValidateIssuerSigningKey = true,
                            ValidIssuer = configRoot["Jwt:Issuer"],
                            ValidAudience = configRoot["Jwt:Issuer"],
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configRoot["Jwt:key"]))
                        };

                    });
        services.AddSwaggerGen(setup =>
        {

            var jwtSecurityScheme = new OpenApiSecurityScheme
            {
                BearerFormat = "JWT",
                Name = "JWT Authentication",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                Scheme = JwtBearerDefaults.AuthenticationScheme,
                Description = "Put **_ONLY_** your JWT Bearer token on textbox below!",

                Reference = new OpenApiReference
                {
                    Id = JwtBearerDefaults.AuthenticationScheme,
                    Type = ReferenceType.SecurityScheme
                }
            };

            setup.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);

            setup.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                { jwtSecurityScheme, Array.Empty<string>() }
            });

        });
        services.AddControllers();


    }
    public void Configure(WebApplication app, IWebHostEnvironment env)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.UseMiddleware<CatchMiddleware>();
        app.UseMiddleware<AuthMiddleWare>();
        app.MapControllers();
        app.MapGet("/", () => "Asa blogger!");

        app.Run();
    }
}