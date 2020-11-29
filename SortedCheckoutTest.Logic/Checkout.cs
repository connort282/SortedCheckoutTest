using SortedCheckoutTest.Logic.Models;
using System;
using System.Collections.Generic;
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
            throw new NotImplementedException();
        }
    }
}
