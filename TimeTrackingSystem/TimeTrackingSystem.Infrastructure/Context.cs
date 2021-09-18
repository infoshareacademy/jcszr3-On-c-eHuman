using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TimeTrackingSystem.Domain.Model;

namespace TimeTrackingSystem.Infrastructure
{
    public class Context : IdentityDbContext
    {
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<TimeSheet> TimeSheets { get; set; }    
        public Context(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.HasDefaultSchema("Identity");
            builder.Entity<IdentityUser>(entity =>
            {
                entity.ToTable(name: "User");
            });
            builder.Entity<IdentityRole>(entity =>
            {
                entity.ToTable(name: "Role");
            });
            builder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.ToTable("UserRoles");
            });
            builder.Entity<IdentityUserClaim<string>>(entity =>
            {
                entity.ToTable("UserClaims");
            });
            builder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.ToTable("UserLogins");
            });
            builder.Entity<IdentityRoleClaim<string>>(entity =>
            {
                entity.ToTable("RoleClaims");
            });
            builder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.ToTable("UserTokens");
            });

            //builder.Entity<Account>()
            //    .HasOne<Role>(it => it.Role)
            //    .WithMany(i => i.Accounts)
            //    .HasForeignKey(it => it.RoleId);

            //builder.Entity<TimeSheet>()
            //    .HasOne<Account>(it => it.Account)
            //    .WithMany(i => i.TimeSheets)
            //    .HasForeignKey(it => it.AccountId);

            //builder.Entity<TimeSheet>()
            //    .HasOne<Activity>(it => it.Activity)
            //    .WithMany(i => i.TimeSheets)
            //    .HasForeignKey(it => it.ActivityId)
            //    .OnDelete(DeleteBehavior.ClientSetNull);

            //builder.Entity<Project>()
            //    .HasOne<Account>(it => it.Account)
            //    .WithMany(i => i.Projects)
            //    .HasForeignKey(it => it.AccountId);

            //builder.Entity<Activity>()
            //    .HasOne<Project>(it => it.Project)
            //    .WithMany(i => i.Activities)
            //    .HasForeignKey(it => it.ProjectId);

            //builder.Entity<Account>()
            //    .HasOne<Role>(it => it.Role)
            //    .WithMany(i => i.Accounts)
            //    .HasForeignKey(it => it.RoleId);

        }
    }
}
