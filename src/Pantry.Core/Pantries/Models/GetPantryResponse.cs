using System.Collections.Generic;

namespace Pantry.Core.Pantries.Models
{
    public record GetPantryResponse(
        string Name,
        string Description,
        string ContactEmail,
        bool Notifications,
        int PercentFull,
        List<string> Baskets,
        List<string> Errors);
}
