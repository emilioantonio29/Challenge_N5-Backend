using ChallengeN5.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace ChallengeN5.Data.ChallengeN5_DbContext
{
    public class ChallengeN5DbContext : DbContext
    {
        public ChallengeN5DbContext(DbContextOptions options) : base(options) { }
        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<PermissionType> PermissionTypes { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<PermissionTable> PermissionsTable { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Permission>()
                .HasOne(p => p.PermissionType)
                .WithMany()
                .HasForeignKey(p => p.PermissionTypeId);

            modelBuilder.Entity<PermissionTable>().ToView("Permissions");
        }
    }
}