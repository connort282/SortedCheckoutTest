using SortedCheckoutTest.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SortedCheckoutTest.Logic
{
    public class Checkout : ICheckout
    {
        private List<Item> _basket = new List<Item>();
        private IItemLookup _itemLookup;

        public Checkout(IItemLookup itemLookup)
        {
            _itemLookup = itemLookup;
        }

        public bool AddItemToBasket(string SKU)
        {
            if (string.IsNullOrWhiteSpace(SKU))
            {
                throw new ArgumentException($"'{nameof(SKU)}' cannot be null or whitespace", nameof(SKU));
            }

            var item = _itemLookup.GetItem(SKU);

            if (item != null)
            {
                _basket.Add(item);
                return true;
            }
            else
            {
                return false;
            }
        }

        public decimal GetTotalPrice()
        {
            return _basket.Sum(x => x.Price);
        }
    }
}
