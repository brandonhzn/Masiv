using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) :base(options){
        }

        public DbSet<User> Users {get;set;}
        public DbSet<Roulette> Roulettes {get;set;}
        public DbSet<Bet> Bet { get; set; }
        public DbSet<Photo> Photos { get; set; }
    }
}