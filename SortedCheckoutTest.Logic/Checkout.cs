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
        private ISpecialOfferLookup _getSpecialOffers;

        public Checkout(IItemLookup itemLookup, ISpecialOfferLookup getSpecialOffers)
        {
            _itemLookup = itemLookup;
            _getSpecialOffers = getSpecialOffers;
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
            var specialOffers = _getSpecialOffers.GetSpecialOffers();

            decimal total = 0m;

            var grouped = _basket.GroupBy(x => x.SKU);

            foreach (var item in grouped)
            {
                var specialOffer = specialOffers.FirstOrDefault(x => x.SKU == item.Key);
                if (specialOffer != null)
                {

                }
                else
                {
                    total += item.Sum(x => x.Price);
                }
            }

            return total;
        }
    }
}
