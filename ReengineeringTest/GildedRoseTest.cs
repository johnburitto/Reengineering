using Reengineering;

namespace ReengineeringTest
{
    public class GildedRoseTest
    {
        private readonly GildedRose _underTest;

        public GildedRoseTest()
        {
            _underTest = new GildedRose
            {
                Items =
                [
                    new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                    new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                    new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                    new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 5, Quality = 47},
                    new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80},
                    new Item
                    {
                        Name = "Backstage passes to a TAFKAL80ETC concert",
                        SellIn = 15,
                        Quality = 20
                    },
                    new Item
                    {
                        Name = "Backstage passes to a TAFKAL80ETC concert",
                        SellIn = 10,
                        Quality = 49
                    },
                    new Item
                    {
                        Name = "Backstage passes to a TAFKAL80ETC concert",
                        SellIn = 5,
                        Quality = 49
                    },
                    new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
                ]
            };
        }

        [Fact]
        public void CommomItemTest_NormalFlow()
        {
            // Given
            int days = 3;
            var result = string.Empty;
            var itemIndex = 0;

            // When
            for (int i = 0; i < days; i++)
            {
                result = $"Day #{i + 1} | {_underTest.Items?[itemIndex].Name} | SellIn: {_underTest.Items?[itemIndex].SellIn}, Quality: {_underTest.Items?[itemIndex].Quality}";
                _underTest.UpdateQuality();
            }

            // Then
            Assert.Contains("Day #3", result);
            Assert.Contains("SellIn: 8", result);
            Assert.Contains("Quality: 18", result);
        }
        
        [Fact]
        public void CommomItemTest_SellInOut()
        {
            // Given
            int days = 12;
            var result = string.Empty;
            var itemIndex = 0;

            // When
            for (int i = 0; i < days; i++)
            {
                result = $"Day #{i + 1} | {_underTest.Items?[itemIndex].Name} | SellIn: {_underTest.Items?[itemIndex].SellIn}, Quality: {_underTest.Items?[itemIndex].Quality}";
                _underTest.UpdateQuality();
            }

            // Then
            Assert.Contains("Day #12", result);
            Assert.Contains("SellIn: 0", result);
            Assert.Contains("Quality: 8", result);
        }
        
        [Fact]
        public void CommomItemTest_ZeroQuality()
        {
            // Given
            int days = 21;
            var result = string.Empty;
            var itemIndex = 0;

            // When
            for (int i = 0; i < days; i++)
            {
                result = $"Day #{i + 1} | {_underTest.Items?[itemIndex].Name} | SellIn: {_underTest.Items?[itemIndex].SellIn}, Quality: {_underTest.Items?[itemIndex].Quality}";
                _underTest.UpdateQuality();
            }

            // Then
            Assert.Contains("Day #21", result);
            Assert.Contains("SellIn: 0", result);
            Assert.Contains("Quality: 0", result);
        }

        [Fact]
        public void AggedBrieTest_NormalFlow()
        {
            // Given
            int days = 15;
            var result = string.Empty;
            var itemIndex = 1;

            // When
            for (int i = 0; i < days; i++)
            {
                result = $"Day #{i + 1} | {_underTest.Items?[itemIndex].Name} | SellIn: {_underTest.Items?[itemIndex].SellIn}, Quality: {_underTest.Items?[itemIndex].Quality}";
                _underTest.UpdateQuality();
            }

            // Then
            Assert.Contains("Day #15", result);
            Assert.Contains("SellIn: 0", result);
            Assert.Contains("Quality: 14", result);
        }

        [Fact]
        public void LegendarySulfuras_NormalFlow()
        {
            // Given
            int days = 12;
            var result = string.Empty;
            var itemIndex = 3;

            // When
            for (int i = 0; i < days; i++)
            {
                result = $"Day #{i + 1} | {_underTest.Items?[itemIndex].Name} | SellIn: {_underTest.Items?[itemIndex].SellIn}, Quality: {_underTest.Items?[itemIndex].Quality}";
                _underTest.UpdateQuality();
            }

            // Then
            Assert.Contains("Day #12", result);
            Assert.Contains("SellIn: 0", result);
            Assert.Contains("Quality: 47", result);
        }

        [Fact]
        public void LegendarySulfuras_SellInNormalize()
        {
            // Given
            int days = 17;
            var result = string.Empty;
            var itemIndex = 4;

            // When
            for (int i = 0; i < days; i++)
            {
                result = $"Day #{i + 1} | {_underTest.Items?[itemIndex].Name} | SellIn: {_underTest.Items?[itemIndex].SellIn}, Quality: {_underTest.Items?[itemIndex].Quality}";
                _underTest.UpdateQuality();
            }

            // Then
            Assert.Contains("Day #17", result);
            Assert.Contains("SellIn: 0", result);
        }

        [Fact]
        public void LegendarySulfuras_QualityInNormalize()
        {
            // Given
            int days = 3;
            var result = string.Empty;
            var itemIndex = 4;

            // When
            for (int i = 0; i < days; i++)
            {
                result = $"Day #{i + 1} | {_underTest.Items?[itemIndex].Name} | SellIn: {_underTest.Items?[itemIndex].SellIn}, Quality: {_underTest.Items?[itemIndex].Quality}";
                _underTest.UpdateQuality();
            }

            // Then
            Assert.Contains("Day #3", result);
            Assert.Contains("Quality: 50", result);
        }

        [Fact]
        public void BackstagePasses_NormalFlow()
        {
            // Given
            int days = 3;
            var result = string.Empty;
            var itemIndex = 5;

            // When
            for (int i = 0; i < days; i++)
            {
                result = $"Day #{i + 1} | {_underTest.Items?[itemIndex].Name} | SellIn: {_underTest.Items?[itemIndex].SellIn}, Quality: {_underTest.Items?[itemIndex].Quality}";
                _underTest.UpdateQuality();
            }

            // Then
            Assert.Contains("Day #3", result);
            Assert.Contains("SellIn: 13", result);
            Assert.Contains("Quality: 20", result);
        }

        [Fact]
        public void BackstagePasses_CloseToConcert()
        {
            // Given
            int days = 7;
            var result = string.Empty;
            var itemIndex = 5;

            // When
            for (int i = 0; i < days; i++)
            {
                result = $"Day #{i + 1} | {_underTest.Items?[itemIndex].Name} | SellIn: {_underTest.Items?[itemIndex].SellIn}, Quality: {_underTest.Items?[itemIndex].Quality}";
                _underTest.UpdateQuality();
            }

            // Then
            Assert.Contains("Day #7", result);
            Assert.Contains("SellIn: 9", result);
            Assert.Contains("Quality: 22", result);
        }
        
        [Fact]
        public void BackstagePasses_VeryCloseToConcert()
        {
            // Given
            int days = 12;
            var result = string.Empty;
            var itemIndex = 5;

            // When
            for (int i = 0; i < days; i++)
            {
                result = $"Day #{i + 1} | {_underTest.Items?[itemIndex].Name} | SellIn: {_underTest.Items?[itemIndex].SellIn}, Quality: {_underTest.Items?[itemIndex].Quality}";
                _underTest.UpdateQuality();
            }

            // Then
            Assert.Contains("Day #12", result);
            Assert.Contains("SellIn: 4", result);
            Assert.Contains("Quality: 33", result);
        }
        
        [Fact]
        public void BackstagePasses_AfterConcert()
        {
            // Given
            int days = 19;
            var result = string.Empty;
            var itemIndex = 5;

            // When
            for (int i = 0; i < days; i++)
            {
                result = $"Day #{i + 1} | {_underTest.Items?[itemIndex].Name} | SellIn: {_underTest.Items?[itemIndex].SellIn}, Quality: {_underTest.Items?[itemIndex].Quality}";
                _underTest.UpdateQuality();
            }

            // Then
            Assert.Contains("Day #19", result);
            Assert.Contains("SellIn: 0", result);
            Assert.Contains("Quality: 0", result);
        }
        
        [Fact]
        public void BackstagePasses_QualityNormalize()
        {
            // Given
            int days = 3;
            var result = string.Empty;
            var itemIndex = 6;

            // When
            for (int i = 0; i < days; i++)
            {
                result = $"Day #{i + 1} | {_underTest.Items?[itemIndex].Name} | SellIn: {_underTest.Items?[itemIndex].SellIn}, Quality: {_underTest.Items?[itemIndex].Quality}";
                _underTest.UpdateQuality();
            }

            // Then
            Assert.Contains("Day #3", result);
            Assert.Contains("SellIn: 8", result);
            Assert.Contains("Quality: 50", result);
        }
        
        [Fact]
        public void ConjuredItems_QualityNormalize()
        {
            // Given
            int days = 2;
            var result = string.Empty;
            var itemIndex = 8;

            // When
            for (int i = 0; i < days; i++)
            {
                result = $"Day #{i + 1} | {_underTest.Items?[itemIndex].Name} | SellIn: {_underTest.Items?[itemIndex].SellIn}, Quality: {_underTest.Items?[itemIndex].Quality}";
                _underTest.UpdateQuality();
            }

            // Then
            Assert.Contains("Day #2", result);
            Assert.Contains("SellIn: 2", result);
            Assert.Contains("Quality: 4", result);
        }

        [Fact]
        public void AgedBrie_IncreaseQualityOverTime()
        {
            // Given
            int days = 10;
            var result = string.Empty;
            var itemIndex = 1;

            // When
            for (int i = 0; i < days; i++)
            {
                result = $"Day #{i + 1} | {_underTest.Items?[itemIndex].Name} | SellIn: {_underTest.Items?[itemIndex].SellIn}, Quality: {_underTest.Items?[itemIndex].Quality}";
                _underTest.UpdateQuality();
            }

            // Then
            Assert.Contains("Day #10", result);
            Assert.Contains("Quality: 9", result);
        }

        [Fact]
        public void ConjuredItem_QualityDegradesTwiceAsFast()
        {
            // Given
            int days = 4;
            var result = string.Empty;
            var itemIndex = 8;

            // When
            for (int i = 0; i < days; i++)
            {
                result = $"Day #{i + 1} | {_underTest.Items?[itemIndex].Name} | SellIn: {_underTest.Items?[itemIndex].SellIn}, Quality: {_underTest.Items?[itemIndex].Quality}";
                _underTest.UpdateQuality();
            }

            // Then
            Assert.Contains("Day #4", result);
            Assert.Contains("Quality: 0", result);
        }

        [Fact]
        public void QualityDoesNotIncreaseAboveFifty()
        {
            // Given
            int days = 56;
            var result = string.Empty;
            var itemIndex = 1;

            // When
            for (int i = 0; i < days; i++)
            {
                result = $"Day #{i + 1} | {_underTest.Items?[itemIndex].Name} | SellIn: {_underTest.Items?[itemIndex].SellIn}, Quality: {_underTest.Items?[itemIndex].Quality}";
                _underTest.UpdateQuality();
            }

            // Then
            Assert.DoesNotContain("Quality: 51", result);
            Assert.Contains("Quality: 50", result);
        }

        [Fact]
        public void SellInDontDecreasesToNegative()
        {
            // Given
            int days = 15;
            var result = string.Empty;
            var itemIndex = 2;

            // When
            for (int i = 0; i < days; i++)
            {
                result = $"Day #{i + 1} | {_underTest.Items?[itemIndex].Name} | SellIn: {_underTest.Items?[itemIndex].SellIn}, Quality: {_underTest.Items?[itemIndex].Quality}";
                _underTest.UpdateQuality();
            }

            // Then
            Assert.Contains("Day #15", result);
            Assert.Contains("SellIn: 0", result);
        }

        [Fact]
        public void ConjuredItemTest_QualityDegradesPastZero()
        {
            // Given
            int days = 5;
            var result = string.Empty;
            var itemIndex = 8;

            // When
            for (int i = 0; i < days; i++)
            {
                result = $"Day #{i + 1} | {_underTest.Items?[itemIndex].Name} | SellIn: {_underTest.Items?[itemIndex].SellIn}, Quality: {_underTest.Items?[itemIndex].Quality}";
                _underTest.UpdateQuality();
            }

            // Then
            Assert.Contains("Day #5", result);
            Assert.Contains("Quality: 0", result);
        }

        [Fact]
        public void BackstagePasses_MaxQualityBeforeConcert()
        {
            // Given
            int days = 8;
            var result = string.Empty;
            var itemIndex = 6;

            // When
            for (int i = 0; i < days; i++)
            {
                result = $"Day #{i + 1} | {_underTest.Items?[itemIndex].Name} | SellIn: {_underTest.Items?[itemIndex].SellIn}, Quality: {_underTest.Items?[itemIndex].Quality}";
                _underTest.UpdateQuality();
            }

            // Then
            Assert.Contains("Quality: 50", result);
        }

        [Fact]
        public void ItemQualityDegradesTwiceAfterSellIn()
        {
            // Given
            int days = 12;
            var result = string.Empty;
            var itemIndex = 0;

            // When
            for (int i = 0; i < days; i++)
            {
                result = $"Day #{i + 1} | {_underTest.Items?[itemIndex].Name} | SellIn: {_underTest.Items?[itemIndex].SellIn}, Quality: {_underTest.Items?[itemIndex].Quality}";
                _underTest.UpdateQuality();
            }

            // Then
            Assert.Contains("Day #12", result);
            Assert.Contains("Quality: 8", result);
        }

    }
}
