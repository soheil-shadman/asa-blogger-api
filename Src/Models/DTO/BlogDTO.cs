using Microsoft.AspNetCore.Authorization;

namespace AsaBloggerApi.Src.Models.DTO
{
  public record GetBlogDTO(string Id)
  {
    public bool IsValid()
    {
      return !string.IsNullOrEmpty(Id);
    }
  }
  public record GetBlogCommentsDTO(string BlogId)
  {
    public bool IsValid()
    {
      return !string.IsNullOrEmpty(BlogId);
    }
  }
  public record GetUserCommentsDTO(string UserId)
  {
    public bool IsValid()
    {
      return !string.IsNullOrEmpty(UserId);
    }
  }
  [Authorize]
  public record CreateBlogDTO(string UserId, string Content, string ImageURL)
  {
    public bool IsValid()
    {
      return !string.IsNullOrEmpty(UserId) && !string.IsNullOrEmpty(Content) && !string.IsNullOrEmpty(ImageURL);
    }
  }
  public record CreateCommentDTO(string UserId, string BlogId, string Content)
  {
    public bool IsValid()
    {
      return !string.IsNullOrEmpty(UserId) && !string.IsNullOrEmpty(BlogId) && !string.IsNullOrEmpty(Content);
    }
  }
  public record EditBlogDTO(string Content,string Id)
  {
    public bool IsValid()
    {
      return !string.IsNullOrEmpty(Content)&&!string.IsNullOrEmpty(Id);
    }
  }
  public record EditCommentDTO(string Content,string Id)
  {
    public bool IsValid()
    {
      return !string.IsNullOrEmpty(Content)&&!string.IsNullOrEmpty(Id);
    }
  }
}