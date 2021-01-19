using Microsoft.EntityFrameworkCore;

namespace PhotoAPI.Model
{
    public partial class PhotoDBContext : DbContext
    {
        public PhotoDBContext()
        {
        }

        public PhotoDBContext(DbContextOptions<PhotoDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Photo> Photos { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=tcp:photoapiserver.database.windows.net,1433;Initial Catalog=PhotoDB;" +
                    "Persist Security Info=False;User ID=mnshevko;Password=Kfdhtynbq1;MultipleActiveResultSets=False;Encrypt=True;" +
                    "TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserLogin).IsUnicode(false);
                entity.Property(e => e.UserPassword).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
