using Reengineering.Entities;
using Reengineering.Entities.FrequentRentalPoints;
using Reengineering.Entities.Prices;

var rembo = new Movie 
{ 
    Title = "Rembo",
    Price = new RegularPrice()
};
var lotr = new Movie 
{ 
    Title = "The Lord of the Rings",
    Price = new NewReleasePrice()
};
var harryPotter = new Movie 
{ 
    Title = "Harry Potter",
    Price = new ChildrensPrice()
};

var rentals = new List<Rental>() 
{ 
    new Rental
    {
        Movie = rembo,
        DaysRented = 1,
        FrequentRentalPoints = new NormalFrequentRentalPoints()
    },
    new Rental
    {
        Movie = lotr,
        DaysRented = 4,
        FrequentRentalPoints = new NewReleaseFrequentRentalPoints()
    },
    new Rental
    {
        Movie = harryPotter,
        DaysRented = 5,
        FrequentRentalPoints = new NormalFrequentRentalPoints()
    }
};
var customer = new Customer
{
    Name = "John Doe",
    Rentals = rentals
};

Console.WriteLine(customer.Statement());
