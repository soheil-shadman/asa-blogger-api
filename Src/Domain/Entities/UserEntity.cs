using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
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
        [AllowNull]
        public DateTime LastLogin { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdateAt { get; set; } = DateTime.Now;

        [ForeignKey("UserId")]
        public ICollection<BlogEntity> Blogs { get; set; } = [];
        [ForeignKey("UserId")]
        public ICollection<CommentEntity> Comments { get; set; } = [];
    }
}
