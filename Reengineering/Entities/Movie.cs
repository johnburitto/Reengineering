using Reengineering.Entities.Prices;

namespace Reengineering.Entities
{
    public class Movie
    {
        public string? Title { get; set; }
        public IPrice? Price { get; set; }
    }
}
