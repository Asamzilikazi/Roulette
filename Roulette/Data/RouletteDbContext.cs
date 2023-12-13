using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Roulette.Models;

namespace Roulette.Data
{
    public class RouletteDbContext : DbContext
    {
        public RouletteDbContext(DbContextOptions<RouletteDbContext> options) : base(options)
        {
        }

        public DbSet<PlaceBet> Bets { get; set; }
    }
}





