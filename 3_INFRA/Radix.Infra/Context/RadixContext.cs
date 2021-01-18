using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Radix.Domain.RadixContext.Entities;
using Radix.Domain.RadixContext.Entities.Authentication;

namespace Radix.Infra.Context
{
    public class RadixContext : DbContext
    {

        public RadixContext()
        {
            this.ChangeTracker.LazyLoadingEnabled = false;
        }
        public RadixContext(DbContextOptions<RadixContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Event> Events { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlite("Data Source=Radix.DB");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(RadixContext).Assembly);
            // modelBuilder.Ignore<Notifiable>();
            // modelBuilder.Ignore<Notification>();

            EntityMapping(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        private void EntityMapping(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>(entity =>
                       {
                           entity.ToTable("User").HasKey(e => e.Id);
                           entity.Property(e => e.identifyer).HasDefaultValueSql("lower(hex(randomblob(16)))");
                           entity.Property(e => e.CreatedAt).HasColumnName("CreatedAt");
                           entity.Property(e => e.UserName)
                               .HasMaxLength(100)
                               .HasColumnName("UserName");
                           entity.Property(e => e.PassWord)
                                .HasMaxLength(100)
                                .HasColumnName("PassWord");
                           entity.Property(e => e.Role)
                                .HasMaxLength(100)
                                .HasColumnName("Role");

                       });

            modelBuilder.Entity<Event>(entity =>
                           {
                               entity.ToTable("Event").HasKey(e => e.Id);
                               entity.Property(e => e.identifyer).HasDefaultValueSql("lower(hex(randomblob(16)))");
                               entity.Property(e => e.CreatedAt).HasColumnName("CreatedAt");
                               
                               entity.Property(e => e.timestamp)
                                    .HasConversion(new TimeSpanToTicksConverter());
                               
                               entity.Property(e => e.tag)
                                    .HasMaxLength(100)
                                    .HasColumnName("tag");
                                
                                entity.Property(e => e.value)
                                    .HasMaxLength(100)
                                    .HasColumnName("value");
                                
                                entity.HasOne(e => e.user)
                                   .WithMany(me => me.Events)
                                   .HasForeignKey(me => me.userId);

                           });

        }


    }
}