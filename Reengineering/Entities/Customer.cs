namespace Reengineering.Entities
{
    public class Customer
    {
        public string? Name { get; set; }
        public List<Rental>? Rentals { get; set; }

        public string Statement()
        {
            var totalAmount = 0.0f;
            var frequentRentalPoints = 0;
            var result = $"Rental Records for {Name}:\n";

            Rentals?.ForEach(rental =>
            {
                var thisAmount = rental.Movie?.Price?.Charge(rental.DaysRented) ?? 0.0f;

                frequentRentalPoints += rental.FrequentRentalPoints?.FrequentRentalPoints(rental.DaysRented) ?? 0;

                result += $"\t{rental.Movie?.Title}\t{thisAmount}\n";
                totalAmount += thisAmount;
            });

            result += $"\nAmount owned {totalAmount}\n";
            result += $"You earned {frequentRentalPoints} frequent renter points";

            return result;
        }
    }
}
