using Microsoft.EntityFrameworkCore;

public class EFDataContext: DbContext
    {
        public EFDataContext(DbContextOptions<EFDataContext> options): base(options) { }
       
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Blog> Blogs { get; set; }
    }