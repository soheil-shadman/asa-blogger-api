using System.ComponentModel.DataAnnotations.Schema;
namespace AsaBloggerApi.Src.Domain.Entities
{
    [Table("blog")]
    public class BlogEntity
    {
        public int Id { get; set; }
        public string? Content { get; set; }
        public string? ImageURL { get; set; } = string.Empty;
        public DateTime PublishedDate { get; set; }= DateTime.Now;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdateAt { get; set; } = DateTime.Now;
        public ICollection<CommentEntity> Comments { get; set; } = [];

        [ForeignKey("User")]
        public int UserId { get; set; }
        public UserEntity? User { get; set; }


    }
}
