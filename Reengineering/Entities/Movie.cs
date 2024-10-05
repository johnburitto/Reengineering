using Reengineering.Enums;

namespace Reengineering.Entities
{
    public class Movie
    {
        public string? Title { get; set; }
        public MovieType Type { get; set; }

        public float Charge(int daysRented) => Type switch
        {
            MovieType.Regular => daysRented > 2 ? 2 + ((daysRented - 2) * 1.5f) : 2,
            MovieType.NewRelease => daysRented * 3,
            MovieType.Childrens => daysRented > 3 ? 1.5f + ((daysRented - 3) * 1.5f) : 1.5f,
            _ => 0f
        };
    }
}
