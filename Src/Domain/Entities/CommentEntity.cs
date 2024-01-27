using System.ComponentModel.DataAnnotations.Schema;
namespace AsaBloggerApi.Src.Domain.Entities
{
    [Table("comment")]
    public class CommentEntity
    {
        public int Id { get; set; }
        public string? Content { get; set; }
        public DateTime PublishedDate { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public UserEntity? User { get; set; }

        [ForeignKey("Blog")]
        public int BlogId { get; set; }
        public BlogEntity? Blog { get; set; }
    }
}