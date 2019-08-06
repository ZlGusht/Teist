namespace Teist.Data
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Threading;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    using Teist.Data.Common.Models;
    using Teist.Data.Models;

    public class TeistDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        private static readonly MethodInfo SetIsDeletedQueryFilterMethod =
            typeof(TeistDbContext).GetMethod(
                nameof(SetIsDeletedQueryFilter),
                BindingFlags.NonPublic | BindingFlags.Static);

        public TeistDbContext(DbContextOptions<TeistDbContext> options)
            : base(options)
        {
        }

        public DbSet<Artist> Artists { get; set; }

        public DbSet<Album> Albums { get; set; }

        public DbSet<Chart> Charts { get; set; }

        public DbSet<Piece> Pieces { get; set; }

        public DbSet<Review> Reviews { get; set; }

        public override int SaveChanges() => this.SaveChanges(true);

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            this.ApplyAuditInfoRules();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken)) =>
            this.SaveChangesAsync(true, cancellationToken);

        public override Task<int> SaveChangesAsync(
            bool acceptAllChangesOnSuccess,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            this.ApplyAuditInfoRules();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Needed for Identity models configuration
            base.OnModelCreating(builder);

            ConfigureUserIdentityRelations(builder);
            ConfigureRelations(builder);

            EntityIndexesConfiguration.Configure(builder);

            var entityTypes = builder.Model.GetEntityTypes().ToList();

            // Set global query filter for not deleted entities only
            var deletableEntityTypes = entityTypes
                .Where(et => et.ClrType != null && typeof(IDeletableEntity).IsAssignableFrom(et.ClrType));
            foreach (var deletableEntityType in deletableEntityTypes)
            {
                var method = SetIsDeletedQueryFilterMethod.MakeGenericMethod(deletableEntityType.ClrType);
                method.Invoke(null, new object[] { builder });
            }

            // Disable cascade delete
            var foreignKeys = entityTypes
                .SelectMany(e => e.GetForeignKeys().Where(f => f.DeleteBehavior == DeleteBehavior.Cascade));
            foreach (var foreignKey in foreignKeys)
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }

        private static void ConfigureUserIdentityRelations(ModelBuilder builder)
        {
            builder.Entity<ApplicationUser>()
                .HasMany(e => e.Claims)
                .WithOne()
                .HasForeignKey(e => e.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<ApplicationUser>()
                .HasMany(e => e.Logins)
                .WithOne()
                .HasForeignKey(e => e.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<ApplicationUser>()
                .HasMany(e => e.Roles)
                .WithOne()
                .HasForeignKey(e => e.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }

        private static void ConfigureRelations(ModelBuilder builder)
        {
            builder.Entity<Album>(album => {
                album.HasOne(a => a.Performer).WithMany(p => p.Albums);
                album.HasMany(a => a.Collaborators);
                album.HasMany(a => a.Pieces).WithOne(p => p.Album);
                album.HasMany(a => a.Reviews).WithOne(r => r.Album);
                album.HasMany(a => a.Charts);
            });
            builder.Entity<Artist>(artist =>
            {
                artist.HasMany(a => a.Albums).WithOne(a => a.Performer);
                artist.HasMany(a => a.Pieces).WithOne(a => a.Performer);
            });
            builder.Entity<Chart>(chart =>
            {
                chart.HasMany(a => a.Pieces);
            });
            builder.Entity<Piece>(piece =>
            {
                piece.HasOne(p => p.Performer).WithMany(p => p.Pieces);
                piece.HasOne(p => p.Album).WithMany(a => a.Pieces);
                piece.HasMany(p => p.Reviews).WithOne(r => r.Piece);
                piece.HasOne(p => p.Chart);
            });
            builder.Entity<Review>(review =>
            {
                review.HasOne(r => r.Piece).WithMany(p => p.Reviews);
                review.HasOne(r => r.Album).WithMany(a => a.Reviews);
                review.HasOne(r => r.Reviewer).WithMany(u => u.Reviews);
            });

        }

        private static void SetIsDeletedQueryFilter<T>(ModelBuilder builder)
            where T : class, IDeletableEntity
        {
            builder.Entity<T>().HasQueryFilter(e => !e.IsDeleted);
        }

        private void ApplyAuditInfoRules()
        {
            var changedEntries = this.ChangeTracker
                .Entries()
                .Where(e =>
                    e.Entity is IAuditInfo &&
                    (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entry in changedEntries)
            {
                var entity = (IAuditInfo)entry.Entity;
                if (entry.State == EntityState.Added && entity.CreatedOn == default(DateTime))
                {
                    entity.CreatedOn = DateTime.UtcNow;
                }
                else
                {
                    entity.ModifiedOn = DateTime.UtcNow;
                }
            }
        }
    }
}
