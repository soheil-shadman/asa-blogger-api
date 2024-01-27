namespace AsaBloggerApi.Src.Models.DTO{
  public record GetBlogDTO(string Id);
  public record GetCommentsDTO(string BlogId);
  public record CreateBlogDTO(string Username, string Password);
  public record CreateCommentDTO(string Token);
}