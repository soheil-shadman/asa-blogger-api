namespace AsaBloggerApi.Src.Models{
    public class BlogModel
{
    public int Id { get; set; }
    public string? Content { get; set; } 
    public string? ImageURL { get; set; } =string.Empty;
    public int UserId { get; set; }
    public DateTime PublishedDate { get; set; }
 
}
}
