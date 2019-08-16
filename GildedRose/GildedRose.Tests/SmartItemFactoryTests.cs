using System;
using Xunit;

namespace GildedRose.Implementation.GildedRose.Tests
{
    public class SmartItemFactoryTests
    {
        private const string AgedBrie = "Aged Brie";
        private const string BackstagePass = "Backstage passes to a TAFKAL80ETC concert";
        private const string SulfurasHandOfRagnaros = "Sulfuras, Hand of Ragnaros";

        [Theory]
        [InlineData(AgedBrie, typeof(AgedBrieSmartItem))]
        [InlineData(BackstagePass, typeof(BackstagePassSmartItem))]
        [InlineData(SulfurasHandOfRagnaros, typeof(SulfurasSmartItem))]
        [InlineData("generic-item", typeof(GenericSmartItem))]
        public void GivenItemName_ReturnsValidSmartItem(string itemName, Type expectedType)
        {
            var item = new Item
            {
                Name = itemName
            };
            
            var smartItemFactory = new SmartItemFactory();
            var smartItem = smartItemFactory.Create(item);
            Assert.IsType(expectedType, smartItem);
        }
    }
}