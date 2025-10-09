using SAP_Backend.Models;

namespace SAP_Backend.Domain.DTO
{
    public class TeamDTO
    {
        public required int Round { get; set; }
        public required int Wins { get; set; }

        // This array needs to only ever be 5
        public required List<string> Members { get; set; }
    }
}
