using Microsoft.EntityFrameworkCore;

public class EF_DataContext: DbContext
    {
        public EF_DataContext(DbContextOptions<EF_DataContext> options): base(options) { }
       
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Blog> Blogs { get; set; }
    }