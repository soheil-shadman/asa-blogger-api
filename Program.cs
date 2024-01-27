using AsaBloggerApi;
var builder = WebApplication.CreateBuilder(args);
Config.InitConfig(builder.Configuration["Jwt:Key"], builder.Configuration["Jwt:Issuer"]);
var startup = new Startup(builder.Configuration);
startup.ConfigureServices(builder.Services);
var app = builder.Build();
startup.Configure(app, builder.Environment);