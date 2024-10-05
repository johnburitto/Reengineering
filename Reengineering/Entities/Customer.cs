using Reengineering.Enums;

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
                var thisAmount = 0.0f;

                switch (rental.Movie?.Type)
                {
                    case MovieType.Regular: thisAmount += rental.DaysRented > 2 ? 2 + ((rental.DaysRented - 2) * 1.5f) : 2; break;
                    case MovieType.NewRelease: thisAmount += rental.DaysRented * 3; break;
                    case MovieType.Childrens:thisAmount += rental.DaysRented > 3 ? 1.5f + ((rental.DaysRented - 3) * 1.5f) : 1.5f; break;
                    default: break;
                }

                frequentRentalPoints += rental.Movie?.Type == MovieType.NewRelease && rental.DaysRented > 1 ? 2 : 1;

                result += $"\t{rental.Movie?.Title}\t{thisAmount}\n";
                totalAmount += thisAmount;
            });

            result += $"\nAmount owned {totalAmount}\n";
            result += $"You earned {frequentRentalPoints} frequent renter points";

            return result;
        }
    }
}
