using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Persistance.User;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance
{
    public class MicroservicesDbContext : DbContext
    {
        public DbSet<Core.Entities.User> Users { get; set; }
        public MicroservicesDbContext(DbContextOptions<MicroservicesDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}