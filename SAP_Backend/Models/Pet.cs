namespace SAP_Backend.Models
{
    using Microsoft.EntityFrameworkCore;

    public class PetContext : DbContext
    {
        public string DbPath { get; }

        public PetContext(DbContextOptions<PetContext> options) : base(options)
        {
            DbPath = "SQLiteDB.db";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options) => 

        public DbSet<Pet> Pets { get; set; } = null!;
    }

    public class Pet
    {
        public required string Name { get; set; }
        public required int Turn { get; set; }
    }
}
