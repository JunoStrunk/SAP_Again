namespace SAP_Backend.Models
{
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;

    public class TeamContext : DbContext
    {
        public TeamContext(DbContextOptions<TeamContext> options) : base(options) { }

        public DbSet<Team> Teams { get; set; } = null!;
    }

    public class Team
    {
        [Key]
        public required long Id { get; set; }
        public required int Round { get; set; }
        public required int Wins { get; set; }

        // This array needs to only ever be 5
        public required List<string> PetIds { get; set; }
    }
}
