using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Entity;
using Microsoft.Data.Sqlite;
using Windows.Storage;
using System.IO;

namespace ShEM.BazaPodataka.Models
{
    public class KorisnikDBContext : DbContext
    {
        public DbSet<Korisnik> korisnici { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optBuilder)
        {
            string DBPath = "BazaKorisnika.db";

            try
            {
                DBPath = Path.Combine(ApplicationData.Current.LocalFolder.Path, DBPath);
            }
            catch(InvalidOperationException)
            {
                optBuilder.UseSqlite($"Data source = {DBPath}");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBulider)
        {
            modelBulider.Entity<Korisnik>().Property(p => p.picture).HasColumnType("picture");
        }
    }
}
