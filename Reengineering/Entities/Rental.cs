using Reengineering.Enums;

namespace Reengineering.Entities
{
    public class Rental
    {
        public Movie? Movie { get; set; }
        public int DaysRented { get; set; }

        public int FrequentRentalPoints() => Movie?.Type switch
        {
            MovieType.NewRelease => DaysRented > 1 ? 2 : 1,
            _ => 1
        };
    }
}
