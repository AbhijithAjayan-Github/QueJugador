using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QueJugadorApp.Models.Entity;
namespace QueJugadorApp.Data
{
    // ApplicationDbContext acts as bridge btw our application and the server
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options) { }
      
        // using MyPlayers we can access the sql database table 
        public DbSet<Player>MyPlayers { get; set; }
    }
}