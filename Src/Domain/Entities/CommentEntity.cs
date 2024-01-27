using System.ComponentModel.DataAnnotations.Schema;
namespace AsaBloggerApi.Src.Domain.Entities
{
    [Table("comment")]
    public class CommentEntity
    {
        public int Id { get; set; }
        public string? Content { get; set; }
        public DateTime PublishedDate { get; set; }= DateTime.Now;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdateAt { get; set; } = DateTime.Now;

        [ForeignKey("User")]
        public int UserId { get; set; }
        public UserEntity? User { get; set; }

        [ForeignKey("Blog")]
        public int BlogId { get; set; }
        public BlogEntity? Blog { get; set; }
    }
}