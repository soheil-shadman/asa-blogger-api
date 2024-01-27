using System.ComponentModel.DataAnnotations.Schema;
namespace AsaBloggerApi.Src.Domain.Entities
{
    [Table("blog")]
    public class BlogEntity
    {
        public int Id { get; set; }
        public string? Content { get; set; }
        public string? ImageURL { get; set; } = string.Empty;
        public DateTime PublishedDate { get; set; }
        public ICollection<CommentEntity> Comments { get; set; } = [];

        [ForeignKey("User")]
        public int UserId { get; set; }
        public UserEntity? User { get; set; }


    }
}
