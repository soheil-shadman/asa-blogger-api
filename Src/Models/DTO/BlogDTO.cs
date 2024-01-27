namespace AsaBloggerApi.Src.Models.DTO{
  public record GetBlogDTO(string Id){
     public bool IsValid(){
      return !string.IsNullOrEmpty(Id);
    }
  }
  public record GetCommentsDTO(string BlogId){
     public bool IsValid(){
      return !string.IsNullOrEmpty(BlogId);
    }
  }
  public record CreateBlogDTO(string Username, string Password){
     public bool IsValid(){
      return !string.IsNullOrEmpty(Username)&&!string.IsNullOrEmpty(Password);
    }
  }
  public record CreateCommentDTO(string Token){
     public bool IsValid(){
      return !string.IsNullOrEmpty(Token);
    }
  }
}