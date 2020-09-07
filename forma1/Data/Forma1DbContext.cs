using forma1.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace forma1.Data
{
    public class Forma1DbContext : IdentityDbContext<User>
    {
        public Forma1DbContext(DbContextOptions<Forma1DbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Forma1DbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<Team> Teams { get; set; }

    }
}
