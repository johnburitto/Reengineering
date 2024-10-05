namespace Reengineering.Entities.FrequentRentalPoints
{
    public class NewReleaseFrequentRentalPoints : IFrequentRentalPoints
    {
        public int FrequentRentalPoints(int daysRented) => daysRented > 1 ? 2 : 1;
    }
}
