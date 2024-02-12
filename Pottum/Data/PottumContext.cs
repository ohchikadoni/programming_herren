using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pottum.Models;

namespace Pottum.Data
{
    public class PottumContext : DbContext
    {
        public PottumContext (DbContextOptions<PottumContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        public DbSet<Pottum.Models.Diary> Dairy { get; set; }

        public DbSet<Pottum.Models.Post> Post { get; set; }

        public DbSet<Pottum.Models.Tag> Tag { get; set; }

        public DbSet<Pottum.Models.User> User { get; set; }
    }
}
