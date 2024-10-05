namespace Reengineering.Entities.Prices
{
    public class RegularPrice : IPrice
    {
        public float Charge(int daysRented) => daysRented > 2 ? 2 + ((daysRented - 2) * 1.5f) : 2;
    }
}
