using SortedCheckoutTest.Logic;
using System;
using Xunit;

namespace SortedCheckoutTest.Test
{
    public class ItemLookupTests
    {
        [Fact]
        public void GetCorrectItem()
        {
            ItemLookup itemLookup = new ItemLookup();

            var item = itemLookup.GetItem("A99");

            Assert.Equal("A99", item.SKU);
            Assert.Equal(0.50m, item.Price);
        }
    }
}
