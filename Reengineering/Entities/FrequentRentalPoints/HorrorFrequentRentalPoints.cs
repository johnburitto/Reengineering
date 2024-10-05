namespace Reengineering.Entities.FrequentRentalPoints
{
    public class HorrorFrequentRentalPoints : IFrequentRentalPoints
    {
        public int FrequentRentalPoints(int daysRented) => daysRented > 3 ? 2 : 1;
    }
}
