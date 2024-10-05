namespace Reengineering.Entities.Prices
{
    public class ChildrensPrice : IPrice
    {
        public float Charge(int daysRented) => daysRented > 3 ? 1.5f + ((daysRented - 3) * 1.5f) : 1.5f;
    }
}
