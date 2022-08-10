using AudioPlayer2.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioPlayer2.Data
{
    internal class LocalDbContext : DbContext
    {
        public DbSet<Audio> Audios { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=AudioPlayer;Trusted_Connection=True;");
        }
    }
    
}
