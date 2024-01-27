namespace AsaBloggerApi.Src.Models{
public class UserModel{
    public int Id { get; set; }

    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public int NumberOfBlogs { get; set; } = 0;
    public DateTime LastLogin { get; set; }

}
}