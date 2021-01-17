using Microsoft.EntityFrameworkCore;
using Radix.Domain.RadixContext.Entities;
using Radix.Domain.RadixContext.Entities.Authentication;

namespace Radix.Infra.Context
{
    public class RadixContext  : DbContext
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
        
        protected override void OnConfiguring(DbContextOptionsBuilder options){

        }


    }
}