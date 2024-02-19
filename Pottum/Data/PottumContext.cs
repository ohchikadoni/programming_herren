using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pottum.Models;

namespace Pottum.Data
{
    public class PottumContext : IdentityDbContext
    {
        public PottumContext (DbContextOptions<PottumContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        public DbSet<Pottum.Models.Diary> Dairies { get; set; }

        public DbSet<Pottum.Models.Post> Posts { get; set; }

        public DbSet<Pottum.Models.Tag> Tags { get; set; }

        public DbSet<Pottum.Models.User> Users { get; set; }
    }
}
