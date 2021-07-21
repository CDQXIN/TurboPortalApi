using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TurboPortalApi.Entity;

namespace TurboPortalApi.Core
{
    public class TurboPortalContext:DbContext
    {
        public TurboPortalContext()
        {
        }
        public TurboPortalContext(DbContextOptions<TurboPortalContext> options) : base(options)
        {
        }
        public DbSet<Users> Users { get; set; }
        public DbSet<Resources> Resources { get; set; }
        public DbSet<UserResourceMapping> UserResourceMapping { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=PC-20200722CRUR;database=TurboPortalDb;uid=sa;pwd=cxd8290677");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>(entity =>
            {
                //entity.ToTable("Users");
                entity.HasComment("网站用户");
                entity.Property(e => e.Id).HasComment("编号");
                entity.Property(e => e.CreateTime).HasColumnType("datetime").HasComment("创建时间");
                entity.Property(e => e.Mobile).HasMaxLength(12);
            });
            modelBuilder.Entity<Resources>(entity =>
            {
                //entity.ToTable("Users");
                entity.HasComment("课程资源");
                entity.Property(e => e.Id).HasComment("编号");
                entity.Property(e => e.CreateTime).HasColumnType("datetime").HasComment("创建时间");
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
