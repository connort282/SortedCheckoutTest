using SortedCheckoutTest.Logic;
using SortedCheckoutTest.Logic.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace SortedCheckoutTest.Test
{
    public class ItemLookupTests
    {
        [Fact]
        public void GetCorrectItem()
        {
            Dictionary<string, Item> items = new Dictionary<string, Item>()
            {
                {"A99", new Item{SKU = "A99", Price = 0.50m} },
            };

            ItemLookup itemLookup = new ItemLookup(items);

            var item = itemLookup.GetItem("A99");

            Assert.Equal("A99", item.SKU);
            Assert.Equal(0.50m, item.Price);
        }

        [Fact]
        public void GetIncorrectItem()
        {
            Dictionary<string, Item> items = new Dictionary<string, Item>();

            ItemLookup itemLookup = new ItemLookup(items);

            var item = itemLookup.GetItem("IDontExist");

            Assert.Null(item);
        }
    }
}
