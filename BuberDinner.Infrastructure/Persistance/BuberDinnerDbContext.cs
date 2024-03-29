﻿using BuberDinner.Domain.Menu;
using Microsoft.EntityFrameworkCore;

namespace BuberDinner.Infrastructure.Persistance
{
    public class BuberDinnerDbContext : DbContext
    {
        public BuberDinnerDbContext(DbContextOptions<BuberDinnerDbContext> options) :base(options)
        {
            
        }

        public DbSet<Menu> Menus { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BuberDinnerDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }

    }
}
