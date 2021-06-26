using System.Collections.Generic;

namespace Pantry.Core.Pantry.Models
{
    public class GetPantryResponse
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ContactEmail { get; set; }
        public bool Notifications { get; set; }
        public int PercentFull { get; set; }
        public List<string> Baskets { get; set; }
        public List<string> Errors { get; set; }
    }
}
