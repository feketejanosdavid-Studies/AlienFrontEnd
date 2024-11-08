using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UFOAPI.Models;

namespace UFOAPI.Data
{
    public class UFOAPIContext : DbContext
    {
        public UFOAPIContext (DbContextOptions<UFOAPIContext> options)
            : base(options)
        {
        }

        public DbSet<UFOAPI.Models.Alien> Alien { get; set; } = default!;
    }
}
