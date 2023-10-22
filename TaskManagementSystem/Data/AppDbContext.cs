using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using TaskManagementSystem.Data.Entities;
using TaskManagementSystem.Migrations;

namespace TaskManagementSystem.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("name=MyDBConnection")
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Configure the many-to-many relationship between Task and User.
            modelBuilder.Entity<Task>()
            .HasMany(t => t.AssignedUsers)
            .WithMany(u => u.AssignedTasks)
            .Map(m =>
            {
                m.MapLeftKey("TaskID");
                m.MapRightKey("UserID");
                m.ToTable("TaskUser"); // specify the name of the join table here.
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}