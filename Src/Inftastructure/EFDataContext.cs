using AsaBloggerApi.Src.Domain.Entities;
using Microsoft.EntityFrameworkCore;

public class EFDataContext: DbContext
    {
        public EFDataContext(DbContextOptions<EFDataContext> options): base(options) { }
       
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<CommentEntity> Comments { get; set; }
        public DbSet<BlogEntity> Blogs { get; set; }
    }