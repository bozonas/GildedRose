using GildedRose.Console;
using System.Collections.Generic;
using Xunit;

namespace GildedRose.Tests
{
    public class TestAssemblyTests
    {
        [Fact]
        public void TestWithInitialValues()
        {
            var app = new Program();
            var TestItemList = new List<TestItem>();
            TestItemList.Add(new TestItem {
                Item = new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 },
                SellInResult = 9, QualityResult = 19
            });
            TestItemList.Add(new TestItem
            {
                Item = new Item { Name = "Aged Brie", SellIn = 2, Quality = 0 },
                SellInResult = 1, QualityResult = 1
            });
            TestItemList.Add(new TestItem
            {
                Item = new Item { Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7 },
                SellInResult = 4, QualityResult = 6
            });
            TestItemList.Add(new TestItem
            {
                Item = new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 },
                SellInResult = 0, QualityResult = 80
            });
            TestItemList.Add(new TestItem
            {
                Item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20 },
                SellInResult = 14, QualityResult = 21
            });
            TestItemList.Add(new TestItem
            {
                Item = new Item { Name = "Conjured Mana Cake", SellIn = 3, Quality = 6 },
                SellInResult = 2, QualityResult = 4
            });

            foreach (var testItem in TestItemList)
            {
                app.UpdateSingleQuality(testItem.Item);
                Assert.Equal(testItem.QualityResult, testItem.Item.Quality);
                Assert.Equal(testItem.SellInResult, testItem.Item.SellIn);
            }
        }

        [Fact]
        public void TestZero()
        {
            var app = new Program();
            var TestItemList = new List<TestItem>();
            TestItemList.Add(new TestItem
            {
                Item = new Item { Name = "", SellIn = 0, Quality = 0 },
                SellInResult = -1, QualityResult = 0
            });
            TestItemList.Add(new TestItem
            {
                Item = new Item { Name = "Aged Brie", SellIn = 0, Quality = 0 },
                SellInResult = -1, QualityResult = 1
            });
            TestItemList.Add(new TestItem
            {
                Item = new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 0 },
                SellInResult = 0, QualityResult = 0
            });
            TestItemList.Add(new TestItem
            {
                Item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 0 },
                SellInResult = -1, QualityResult = 0
            });
            TestItemList.Add(new TestItem
            {
                Item = new Item { Name = "Conjured Mana Cake", SellIn = 0, Quality = 0 },
                SellInResult = -1, QualityResult = 0
            });

            foreach (var testItem in TestItemList)
            {
                app.UpdateSingleQuality(testItem.Item);
                Assert.Equal(testItem.QualityResult, testItem.Item.Quality);
                Assert.Equal(testItem.SellInResult, testItem.Item.SellIn);
            }
        }

        [Fact]
        public void TestMaxQuality()
        {
            var app = new Program();
            var TestItemList = new List<TestItem>();
            TestItemList.Add(new TestItem
            {
                Item = new Item { Name = "Aged Brie", SellIn = 0, Quality = 50 },
                SellInResult = -1,
                QualityResult = 50
            });
            TestItemList.Add(new TestItem
            {
                Item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 1, Quality = 50 },
                SellInResult = 0,
                QualityResult = 50
            });

            foreach (var testItem in TestItemList)
            {
                app.UpdateSingleQuality(testItem.Item);
                Assert.Equal(testItem.QualityResult, testItem.Item.Quality);
                Assert.Equal(testItem.SellInResult, testItem.Item.SellIn);
            }
        }

        [Fact]
        public void TestBackStage()
        {
            var app = new Program();
            var TestItemList = new List<TestItem>();
            string name = "Backstage passes to a TAFKAL80ETC concert";
            TestItemList.Add(new TestItem
            {
                Item = new Item { Name = name, SellIn = 9, Quality = 20 },
                SellInResult = 8, QualityResult = 22
            });
            TestItemList.Add(new TestItem
            {
                Item = new Item { Name = name, SellIn = 4, Quality = 20 },
                SellInResult = 3, QualityResult = 23
            });
            TestItemList.Add(new TestItem
            {
                Item = new Item { Name = name, SellIn = -1, Quality = 20 },
                SellInResult = -2, QualityResult = 0
            });

            foreach (var testItem in TestItemList)
            {
                app.UpdateSingleQuality(testItem.Item);
                Assert.Equal(testItem.QualityResult, testItem.Item.Quality);
                Assert.Equal(testItem.SellInResult, testItem.Item.SellIn);
            }
        }

        class TestItem
        {
            public Item Item { get; set; }
            public int QualityResult { get; set; }
            public int SellInResult { get; set; }
        }
    }
}