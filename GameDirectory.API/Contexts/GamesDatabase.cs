using System;
using GameDirectory.API.Models;
using Microsoft.EntityFrameworkCore;

namespace GameDirectory.API.Contexts
{
    public class GamesDatabase:DbContext
    {
        public DbSet<Game> Games { get; set; }
        public GamesDatabase(DbContextOptions options) :base(options)
        {
            Database.EnsureCreated();
        }
    }
}
