namespace Reengineering.Entities.Prices
{
    public class NewReleasePrice : IPrice
    {
        public float Charge(int daysRented) => daysRented * 3;
    }
}
