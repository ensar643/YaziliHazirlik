using Microsoft.EntityFrameworkCore;

namespace mvc.Models
{
    public class HazirlikDbContext : DbContext
    {
        string baglantiCumlesi = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=HazirlikDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(baglantiCumlesi);
        }
        public DbSet<Ogrenci> Ogrenciler { get; set; }
        public DbSet<Sinif> Siniflar { get; set; }
    }
}
