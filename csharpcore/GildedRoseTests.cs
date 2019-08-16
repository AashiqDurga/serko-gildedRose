using System.Collections.Generic;
using Xunit;

namespace csharpcore
{
    public class GildedRoseTests
    {
        [Fact]
        public void GivenAgedBrieItem_UpdatesAccordingToAgedBrieSmartItem()
        {
            var item = new Item
            {
                Name = "Aged Brie",
                Quality = 45
            };

            var duplicateItem = new Item
            {
                Name = "Aged Brie",
                Quality = 45
            };

            var smartItem = new AgedBrieSmartItem(duplicateItem);
            smartItem.Update();
            
            var gildedRose = new GildedRose();
            gildedRose.UpdateQuality(new List<Item> { item });
            Assert.Equal(duplicateItem.Quality, item.Quality);
            Assert.Equal(duplicateItem.SellIn, item.SellIn);
        }
    }
}