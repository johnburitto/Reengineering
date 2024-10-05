using Reengineering.Entities;
using Reengineering.Enums;
using System.Collections.Generic;
using System.Text.Json;

var rembo = new Movie 
{ 
    Title = "Rembo",
    Type = MovieType.Regular
};
var lotr = new Movie 
{ 
    Title = "The Lord of the Rings",
    Type = MovieType.NewRelease
};
var harryPotter = new Movie 
{ 
    Title = "Harry Potter",
    Type = MovieType.Childrens
};

var rentals = new List<Rental>() 
{ 
    new Rental
    {
        Movie = rembo,
        DaysRented = 1
    },
    new Rental
    {
        Movie = lotr,
        DaysRented = 4
    },
    new Rental
    {
        Movie = harryPotter,
        DaysRented = 5
    }
};
var customer = new Customer
{
    Name = "John Doe",
    Rentals = rentals
};

Console.WriteLine(JsonSerializer.Serialize(customer));
