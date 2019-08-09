using System.Collections.Generic;
using Xunit;

namespace csharpcore
{
    public class BackstagePassSmartItemTests
    {
        private const string BackstagePasses = "Backstage passes to a TAFKAL80ETC concert";

        [Theory]
        [InlineData(1, 50)]
        [InlineData(5, 50)]
        [InlineData(10, 50)]
        public void GivenBackstagePassWithQuality50AndSellInGreaterThanZero_WhenUpdatingQuality_ThenQualityRemains50(
            int sellIn, int expected)
        {
            var item = new Item
            {
                Name = BackstagePasses,
                Quality = 50,
                SellIn = sellIn
            };

            var smartItem = new BackstagePassSmartItem(item);
            smartItem.Update();
            Assert.Equal(expected, smartItem.Item.Quality);
        }

        [Fact]
        public void
            GivenBackstagePassWithQuality46AndSellInLessThanSix_WhenUpdatingQuality_ThenQualityShouldIncreaseByThree()
        {
            var item = new Item
            {
                Name = BackstagePasses,
                Quality = 46,
                SellIn = 4
            };

            var smartItem = new BackstagePassSmartItem(item);
            smartItem.Update();
            Assert.Equal(49, item.Quality);
        }

        [Fact]
        public void
            GivenBackstagePassWithQuality46AndSellInLessThan11GreaterThan5_WhenUpdatingQuality_ThenQualityShouldIncreaseBy2()
        {
            var item = new Item
            {
                Name = BackstagePasses,
                Quality = 46,
                SellIn = 10
            };

            var smartItem = new BackstagePassSmartItem(item);
            smartItem.Update();
            Assert.Equal(48, item.Quality);
        }

        [Fact]
        public void GivenBackstagePassWithQuality50AndSellInZero_WhenUpdatingQuality_ThenQualityBecomesZero()
        {
            var item = new Item
            {
                Name = BackstagePasses,
                Quality = 50,
                SellIn = 0
            };

            var smartItem = new BackstagePassSmartItem(item);
            smartItem.Update();
            Assert.Equal(0, item.Quality);
        }
    }

    public class BackstagePassSmartItem : ISmartItem
    {
        public BackstagePassSmartItem(Item item)
        {
            Item = item;
        }

        public Item Item { get; set; }

        public void Update()
        {
            HandleBackstagePass();
        }
        
        private void HandleBackstagePass()
        {
            IncreaseQuality();

            if (Item.SellIn <= 10)
            {
                IncreaseQuality();
            }

            if (Item.SellIn <= 5)
            {
                IncreaseQuality();
            }

            DecreaseSellIn();
            if (Item.SellIn < 0)
            {
                Item.Quality = 0;
            }
        }
        
        private void IncreaseQuality()
        {
            if (Item.Quality < 50)
            {
                Item.Quality++;
            }
        }

        private void DecreaseSellIn()
        {
            Item.SellIn--;
        }
    }
}