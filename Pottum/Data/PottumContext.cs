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

        public DbSet<Pottum.Models.Diary> Movie { get; set; }

        public DbSet<Pottum.Models.Diary> Post { get; set; }
    }
}
