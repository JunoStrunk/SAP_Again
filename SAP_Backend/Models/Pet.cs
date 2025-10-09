namespace SAP_Backend.Models
{
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;

    public class PetContext : DbContext
    {
        public string DbPath { get; }

        public PetContext(DbContextOptions<PetContext> options) : base(options)
        {
            DbPath = "SQLiteDB.db";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite($"Data Source={DbPath}");

        public DbSet<Pet> Pets { get; set; } = null!;
    }

    public class Pet
    {
        [Key]
        public required string Name { get; set; }
        public required int Turn { get; set; }
    }
}
