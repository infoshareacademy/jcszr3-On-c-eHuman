using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TimeTrackingSystem.Domain.Model;

namespace TimeTrackingSystem.Infrastructure
{
    public class Context : IdentityDbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<TimeSheet> TimeSheets { get; set; }    
        public Context(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Account>()
                .HasOne<Role>(it => it.Role)
                .WithMany(i => i.Accounts)
                .HasForeignKey(it => it.RoleId);

            builder.Entity<TimeSheet>()
                .HasOne<Account>(it => it.Account)
                .WithMany(i => i.TimeSheets)
                .HasForeignKey(it => it.AccountId);

            builder.Entity<TimeSheet>()
                .HasOne<Activity>(it => it.Activity)
                .WithMany(i => i.TimeSheets)
                .HasForeignKey(it => it.ActivityId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.Entity<Project>()
                .HasOne<Account>(it => it.Account)
                .WithMany(i => i.Projects)
                .HasForeignKey(it => it.AccountId);

            builder.Entity<Activity>()
                .HasOne<Project>(it => it.Project)
                .WithMany(i => i.Activities)
                .HasForeignKey(it => it.ProjectId);

            builder.Entity<Account>()
                .HasOne<Role>(it => it.Role)
                .WithMany(i => i.Accounts)
                .HasForeignKey(it => it.RoleId);

        }
    }
}
