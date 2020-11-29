using SortedCheckoutTest.Logic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SortedCheckoutTest.Logic
{
    public class ItemLookup : IItemLookup
    {
        private IDictionary<string, Item> items;

        public ItemLookup(IDictionary<string, Item> Items)
        {
            items = Items;
        }

        /// <summary>
        /// Retrives the item object if it exists
        /// </summary>
        /// <param name="SKU">SKU of the item</param>
        /// <returns>
        /// Returns null if item does not exist, returns Item if it does exist.
        /// Throws ArgumentException if SKU if null or whitespace
        /// </returns>
        public Item GetItem(string SKU)
        {
            if (string.IsNullOrWhiteSpace(SKU))
            {
                throw new ArgumentException($"'{nameof(SKU)}' cannot be null or whitespace", nameof(SKU));
            }

            items.TryGetValue(SKU, out Item item);
            return item;
        }
    }
}
