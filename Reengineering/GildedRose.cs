namespace Reengineering
{
    public class GildedRose
    {
        public List<Item>? Items {  get; set; }

        public void UpdateQuality()
        {
            Items?.ForEach(item =>
            {
                if (item.Name!.Contains("Sulfuras"))
                {
                    item.Quality = item.Quality <= 0 ? 0 : item.Quality > 50 ? 50 : item.Quality;
                    item.SellIn = item.SellIn <= 0 ? 0 : item.SellIn - 1;

                    return;
                }

                if (item.Name.Contains("Aged Brie"))
                {
                    item.Quality++;
                }
                else if (item.Name.Contains("Backstage passes"))
                {
                    item.Quality = item.SellIn <= 0 ? 0 : item.SellIn <= 5 ? item.Quality + 3 : item.SellIn <= 10 ? item.Quality + 2 : item.Quality;
                }
                else if (item.Name.Contains("Conjured"))
                {
                    item.Quality -= 2;
                }
                else
                {
                    item.Quality = item.SellIn <= 0 ? item.Quality - 2 : item.Quality - 1;
                }

                item.Quality = item.Quality <= 0 ? 0 : item.Quality > 50 ? 50 : item.Quality;
                item.SellIn = item.SellIn <= 0 ? 0 : item.SellIn - 1;
            });
        }
    }
}
