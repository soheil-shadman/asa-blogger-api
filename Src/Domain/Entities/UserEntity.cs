using System.ComponentModel.DataAnnotations.Schema;
namespace AsaBloggerApi.Src.Domain.Entities
{
    [Table("user")]
    public class UserEntity
    {
        public int Id { get; set; }

        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
        public int NumberOfBlogs { get; set; } = 0;
        public DateTime LastLogin { get; set; }

        [ForeignKey("UserId")]
        public ICollection<BlogEntity> Blogs { get; set; } = [];
        [ForeignKey("UserId")]
        public ICollection<CommentEntity> Comments { get; set; } = [];
    }
}
