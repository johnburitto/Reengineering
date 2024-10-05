namespace Reengineering.Entities.Prices
{
    public class HorrorPrice : IPrice
    {
        public float Charge(int daysRented) => daysRented > 7 ? 3f + ((daysRented - 7) * 2f) : 3f;
    }
}
