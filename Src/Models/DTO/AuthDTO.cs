namespace AsaBloggerApi.Src.Models.DTO{
  public record SignupDTO(string Username, string Password,string Email){
    public bool IsValid(){
      return !string.IsNullOrEmpty(Username) &&!string.IsNullOrEmpty(Password) &&!string.IsNullOrEmpty(Email);
    }
  };
  public record LoginDTO(string Username, string Password){
    public bool IsValid(){
      return !string.IsNullOrEmpty(Username) &&!string.IsNullOrEmpty(Password);
    }
  };
  public record CheckTokenDTO(string Token){
     public bool IsValid(){
      return !string.IsNullOrEmpty(Token);
    }
  }
}