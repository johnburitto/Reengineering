namespace Reengineering.Entities.Prices
{
    public interface IPrice
    {
        float Charge(int daysRented);
    }
}
