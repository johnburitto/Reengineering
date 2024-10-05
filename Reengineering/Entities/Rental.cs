﻿using Reengineering.Entities.FrequentRentalPoints;

namespace Reengineering.Entities
{
    public class Rental
    {
        public Movie? Movie { get; set; }
        public int DaysRented { get; set; }
        public IFrequentRentalPoints? FrequentRentalPoints { get; set; }
    }
}
