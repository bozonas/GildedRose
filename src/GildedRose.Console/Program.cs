using System.Collections.Generic;

namespace GildedRose.Console
{
    public class Program
    {
        IList<Item> Items;
        static void Main(string[] args)
        {
            System.Console.WriteLine("OMGHAI!");

            var app = new Program()
            {
                Items = new List<Item>
                {
                    new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                    new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                    new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                    new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                    new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20},
                    new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
                }
            };

            app.UpdateQuality();

            System.Console.ReadKey();
        }

        public void UpdateQuality()
        {
            foreach (Item item in Items)
            {
                UpdateSingleQuality(item);
            }
        }

        public void UpdateSingleQuality(Item item)
        {
            switch(item.Name)
            {
                case "Aged Brie":
                    UpdateQualityAgedBrie(item);
                    break;
                case "Sulfuras, Hand of Ragnaros":
                    //"Sulfuras", being a legendary item, never has to be sold or decreases in Quality
                    break;
                case "Backstage passes to a TAFKAL80ETC concert":
                    UpdateQualityBackstagePasses(item);
                    break;
                case "Conjured Mana Cake":
                    UpdateQualityConjured(item);
                    break;
                default:
                    UpdateQualityStandart(item);
                    break;
            }
        }

        public void UpdateQualityConjured(Item item)
        {
            item.SellIn--;
            item.Quality -= 2;

            // Once the sell by date has passed, Quality degrades twice as fast
            if (item.SellIn < 0)
                item.Quality -= 2;

            // The Quality of an item is never negative
            if (item.Quality < 0)
                item.Quality = 0;
        }

        public void UpdateQualityBackstagePasses(Item item)
        {
            item.SellIn--;
            item.Quality++;

            //Quality drops to 0 after the concert
            if (item.SellIn < 0)
            {
                item.Quality = 0;
                return;
            }

            //Quality increases by 2 when there are 10 days or less
            if (item.SellIn <= 10)
                item.Quality++;

            // by 3 when there are 5 days or less
            if (item.SellIn <= 5)
                item.Quality++;

            if (item.Quality > 50)
                item.Quality = 50;
        }

        public void UpdateQualityAgedBrie(Item item)
        {
            item.SellIn--;

            //The Quality of an item is never more than 50
            if (item.Quality < 50)
                item.Quality++;
        }

        public void UpdateQualityStandart(Item item)
        {
            item.SellIn--;
            item.Quality--;

            // Once the sell by date has passed, Quality degrades twice as fast
            if (item.SellIn < 0)
                item.Quality--;

            // The Quality of an item is never negative
            if (item.Quality < 0)
                item.Quality = 0;
        }
    }
}
