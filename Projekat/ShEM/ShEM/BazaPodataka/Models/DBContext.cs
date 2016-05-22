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
    public class DBContext : DbContext
    {
        public DbSet<Korisnik> korisnici { get; set; }
        public DbSet<Komentar> Komentari { get; set; }
        public DbSet<Kolekcija> Kolekcije { get; set; }
        public DbSet<Film> Filmovi { get; set; }
        public DbSet<Pjesma> Pjesme { get; set; }
        public DbSet<Knjiga> Knjige { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optBuilder)
        {

            string DBPath = "ShEMBaza.db";

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
            modelBulider.Entity<Komentar>().Property(p => p.CreatorPicture).HasColumnType("picture");
            modelBulider.Entity<Kolekcija>().Property(p => p.CollectionPicture).HasColumnType("picture");
            modelBulider.Entity<Film>().Property(p => p.ArticlePicture).HasColumnType("picture");
            modelBulider.Entity<Knjiga>().Property(p => p.ArticlePicture).HasColumnType("picture");
            modelBulider.Entity<Pjesma>().Property(p => p.ArticlePicture).HasColumnType("picture");

        }
    }
}
