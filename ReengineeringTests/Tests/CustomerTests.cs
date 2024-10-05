using Reengineering.Entities;
using Reengineering.Entities.FrequentRentalPoints;
using Reengineering.Entities.Prices;

namespace ReengineeringTests.Tests
{
    public class CustomerTests
    {
        private Movie _rembo = new()
        {
            Title = "Rembo",
            Price = new RegularPrice()
        };
        private Movie _lotr = new()
        {
            Title = "The Lord of the Rings",
            Price = new NewReleasePrice()
        };
        private Movie _harryPotter = new()
        {
            Title = "Harry Potter",
            Price = new ChildrensPrice()
        };
        private Movie _how = new()
        {
            Title = "House of Wax",
            Price = new HorrorPrice()
        };
        private List<Rental> _rentals;
        private Customer _underTest;

        public CustomerTests()
        {
            _rentals = new();
            _underTest = new()
            {
                Name = "John Doe",
                Rentals = _rentals
            };
        }

        [Fact]
        public void Statement_NormalFLow()
        {
            // Given
            _rentals.AddRange([
                    new Rental 
                    {
                        Movie = _rembo,
                        DaysRented = 1,
                        FrequentRentalPoints = new NormalFrequentRentalPoints()
                    },
                    new Rental
                    {
                        Movie = _lotr,
                        DaysRented = 4,
                        FrequentRentalPoints = new NewReleaseFrequentRentalPoints()
                    },
                    new Rental
                    {
                        Movie = _harryPotter,
                        DaysRented = 5,
                        FrequentRentalPoints = new NormalFrequentRentalPoints()
                    }
                ]);

            // When
            var result = _underTest.Statement();

            // Then
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Contains("for John Doe", result);
            Assert.Contains("Rembo\t2", result);
            Assert.Contains("The Lord of the Rings\t12", result);
            Assert.Contains("Harry Potter\t4,5", result);
            Assert.Contains("Amount owned 18,5", result);
            Assert.Contains("You earned 4 frequent renter points", result);
        }

        [Fact]
        public void Statement_RegularWithoutAdditionalAmount()
        {
            // Given
            _rentals.AddRange([
                    new Rental
                    {
                        Movie = _rembo,
                        DaysRented = 1,
                        FrequentRentalPoints = new NormalFrequentRentalPoints()
                    }
                ]);

            // When
            var result = _underTest.Statement();

            // Then
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Contains("for John Doe", result);
            Assert.Contains("Rembo\t2", result);
            Assert.Contains("Amount owned 2", result);
            Assert.Contains("You earned 1 frequent renter points", result);
        }
        
        [Fact]
        public void Statement_RegularWithAdditionalAmount()
        {
            // Given
            _rentals.AddRange([
                    new Rental
                    {
                        Movie = _rembo,
                        DaysRented = 3,
                        FrequentRentalPoints = new NormalFrequentRentalPoints()
                    }
                ]);

            // When
            var result = _underTest.Statement();

            // Then
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Contains("for John Doe", result);
            Assert.Contains("Rembo\t3,5", result);
            Assert.Contains("Amount owned 3,5", result);
            Assert.Contains("You earned 1 frequent renter points", result);
        }

        [Fact]
        public void Statement_NewReleaseWithoutAdditionalFrequentPoints()
        {
            // Given
            _rentals.AddRange([
                    new Rental
                    {
                        Movie = _lotr,
                        DaysRented = 1,
                        FrequentRentalPoints = new NewReleaseFrequentRentalPoints()
                    }
                ]);

            // When
            var result = _underTest.Statement();

            // Then
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Contains("for John Doe", result);
            Assert.Contains("The Lord of the Rings\t3", result);
            Assert.Contains("Amount owned 3", result);
            Assert.Contains("You earned 1 frequent renter points", result);
        }
        
        [Fact]
        public void Statement_NewReleaseWithAdditionalFrequentPoints()
        {
            // Given
            _rentals.AddRange([
                    new Rental
                    {
                        Movie = _lotr,
                        DaysRented = 4,
                        FrequentRentalPoints = new NewReleaseFrequentRentalPoints()
                    }
                ]);

            // When
            var result = _underTest.Statement();

            // Then
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Contains("for John Doe", result);
            Assert.Contains("The Lord of the Rings\t12", result);
            Assert.Contains("Amount owned 12", result);
            Assert.Contains("You earned 2 frequent renter points", result);
        }

        [Fact]
        public void Statement_ChildrensWithoutAdditionalAmount()
        {
            // Given
            _rentals.AddRange([
                    new Rental
                    {
                        Movie = _harryPotter,
                        DaysRented = 1,
                        FrequentRentalPoints = new NormalFrequentRentalPoints()
                    }
                ]);

            // When
            var result = _underTest.Statement();

            // Then
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Contains("for John Doe", result);
            Assert.Contains("Harry Potter\t1,5", result);
            Assert.Contains("Amount owned 1,5", result);
            Assert.Contains("You earned 1 frequent renter points", result);
        }
        
        [Fact]
        public void Statement_ChildrensWithAdditionalAmount()
        {
            // Given
            _rentals.AddRange([
                    new Rental
                    {
                        Movie = _harryPotter,
                        DaysRented = 5,
                        FrequentRentalPoints = new NormalFrequentRentalPoints()
                    }
                ]);

            // When
            var result = _underTest.Statement();

            // Then
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Contains("for John Doe", result);
            Assert.Contains("Harry Potter\t4,5", result);
            Assert.Contains("Amount owned 4,5", result);
            Assert.Contains("You earned 1 frequent renter points", result);
        }

        [Fact]
        public void Statement_HorrorWithoutAdditionalAmount()
        {
            // Given
            _rentals.AddRange([
                    new Rental
                    {
                        Movie = _how,
                        DaysRented = 2,
                        FrequentRentalPoints = new HorrorFrequentRentalPoints()
                    }
                ]);

            // When
            var result = _underTest.Statement();

            // Then
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Contains("for John Doe", result);
            Assert.Contains("House of Wax\t3", result);
            Assert.Contains("Amount owned 3", result);
            Assert.Contains("You earned 1 frequent renter points", result);
        }
        
        [Fact]
        public void Statement_HorrorWithAdditionalAmountAndFrequentRentalPoints()
        {
            // Given
            _rentals.AddRange([
                    new Rental
                    {
                        Movie = _how,
                        DaysRented = 8,
                        FrequentRentalPoints = new HorrorFrequentRentalPoints()
                    }
                ]);

            // When
            var result = _underTest.Statement();

            // Then
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Contains("for John Doe", result);
            Assert.Contains("House of Wax\t5", result);
            Assert.Contains("Amount owned 5", result);
            Assert.Contains("You earned 2 frequent renter points", result);
        }

        [Fact]
        public void Statement_WithoutFilm()
        {
            // Given
            _rentals.AddRange([
                    new Rental
                    {
                        Movie = null,
                        DaysRented = 5,
                        FrequentRentalPoints = new NormalFrequentRentalPoints()
                    }
                ]);

            // When
            var result = _underTest.Statement();

            // Then
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Contains("for John Doe", result);
            Assert.Contains("\t0", result);
            Assert.Contains("Amount owned 0", result);
            Assert.Contains("You earned 1 frequent renter points", result);
        }
        
        [Fact]
        public void Statement_WithoutFrequentRentalPoints()
        {
            // Given
            _rentals.AddRange([
                    new Rental
                    {
                        Movie = _rembo,
                        DaysRented = 1,
                        FrequentRentalPoints = null
                    }
                ]);

            // When
            var result = _underTest.Statement();

            // Then
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Contains("for John Doe", result);
            Assert.Contains("Rembo\t2", result);
            Assert.Contains("Amount owned 2", result);
            Assert.Contains("You earned 0 frequent renter points", result);
        }
    }
}
