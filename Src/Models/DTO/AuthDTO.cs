namespace AsaBloggerApi.Src.Models.DTO{
  public record SignupDTO(string Username, string Password,string Email);
  public record LoginDTO(string Username, string Password);
  public record CheckTokenDTO(string Token);
}