using System.Collections.Generic;
using Moq;
using Xunit;

namespace csharpcore
{
    public class GildedRoseTests
    {
        private readonly GildedRose _gildedRose;
        private readonly Mock<ISmartItemFactory> _smartItemFactoryMock;

        public GildedRoseTests()
        {
            _smartItemFactoryMock = new Mock<ISmartItemFactory>();
            _gildedRose = new GildedRose(_smartItemFactoryMock.Object);
        }

        private const string AgedBrie = "Aged Brie";
        private const string BackstagePass = "Backstage passes to a TAFKAL80ETC concert";
        private const string SulfurasHandOfRagnaros = "Sulfuras, Hand of Ragnaros";
        
        [Theory]
        [InlineData(AgedBrie)]
        [InlineData(SulfurasHandOfRagnaros)]
        [InlineData(BackstagePass)]
        [InlineData("Generic")]
        public void GivenItemList_UpdatesItem(string itemName)
        {
            var item = new Item
            {
                Name = itemName,
                Quality = 45
            };

            var items = new List<Item> {item};

            var smartItemMock = new Mock<ISmartItem>();
            _smartItemFactoryMock.Setup(f => f.Create(item)).Returns(smartItemMock.Object);
            _gildedRose.UpdateQuality(items);

            _smartItemFactoryMock.Verify(f => f.Create(item), Times.Once);
            smartItemMock.Verify(i => i.Update(), Times.Once);
        }
    }
}