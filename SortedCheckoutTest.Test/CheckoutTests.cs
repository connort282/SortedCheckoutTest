using SortedCheckoutTest.Logic;
using SortedCheckoutTest.Logic.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SortedCheckoutTest.Test
{
    public class CheckoutTests
    {
        [Fact]
        public void AddCorrectItemToBasket()
        {
            Dictionary<string, Item> items = new Dictionary<string, Item>()
            {
                {"A99", new Item{SKU = "A99", Price = 0.50m} },
            };

            ItemLookup itemLookup = new ItemLookup(items);
            SpecialOfferLookup specialOfferLookup = new SpecialOfferLookup(new List<SpecialOffer>());

            Checkout checkout = new Checkout(itemLookup, specialOfferLookup);

            var result = checkout.AddItemToBasket("A99");

            Assert.True(result);
        }

        [Fact]
        public void AddIncorrectItemToBasket()
        {
            Dictionary<string, Item> items = new Dictionary<string, Item>();

            ItemLookup itemLookup = new ItemLookup(items);

            SpecialOfferLookup specialOfferLookup = new SpecialOfferLookup(new List<SpecialOffer>());

            Checkout checkout = new Checkout(itemLookup, specialOfferLookup);

            var result = checkout.AddItemToBasket("IDontExist");

            Assert.False(result);
        }

        [Fact]
        public void GetBasketTotalWithoutOffers()
        {
            Dictionary<string, Item> items = new Dictionary<string, Item>()
            {
                {"A99", new Item{SKU = "A99", Price = 0.50m} },
            };

            ItemLookup itemLookup = new ItemLookup(items);
            SpecialOfferLookup specialOfferLookup = new SpecialOfferLookup(new List<SpecialOffer>());

            Checkout checkout = new Checkout(itemLookup, specialOfferLookup);

            _ = checkout.AddItemToBasket("A99");
            _ = checkout.AddItemToBasket("A99");

            var result = checkout.GetTotalPrice();

            Assert.Equal(1m, result);
        }

        [Fact]
        public void GetBasketTotalWithOffersWithNoLeft()
        {
            Dictionary<string, Item> items = new Dictionary<string, Item>()
            {
                {"A99", new Item{SKU = "A99", Price = 0.50m} },
            };

            List<SpecialOffer> specialOffers = new List<SpecialOffer>()
            {
                new SpecialOffer(){SKU = "A99", Quantity = 3, Price = 1.30m },
            };

            ItemLookup itemLookup = new ItemLookup(items);
            SpecialOfferLookup specialOfferLookup = new SpecialOfferLookup(specialOffers);

            Checkout checkout = new Checkout(itemLookup, specialOfferLookup);

            _ = checkout.AddItemToBasket("A99");
            _ = checkout.AddItemToBasket("A99");
            _ = checkout.AddItemToBasket("A99");

            var result = checkout.GetTotalPrice();

            Assert.Equal(1.30m, result);
        }

        [Fact]
        public void GetBasketTotalWithOffersWithOneLeft()
        {
            Dictionary<string, Item> items = new Dictionary<string, Item>()
            {
                {"A99", new Item{SKU = "A99", Price = 0.50m} },
            };

            List<SpecialOffer> specialOffers = new List<SpecialOffer>()
            {
                new SpecialOffer(){SKU = "A99", Quantity = 3, Price = 1.30m },
            };

            ItemLookup itemLookup = new ItemLookup(items);
            SpecialOfferLookup specialOfferLookup = new SpecialOfferLookup(specialOffers);

            Checkout checkout = new Checkout(itemLookup, specialOfferLookup);

            _ = checkout.AddItemToBasket("A99");
            _ = checkout.AddItemToBasket("A99");
            _ = checkout.AddItemToBasket("A99");
            _ = checkout.AddItemToBasket("A99");

            var result = checkout.GetTotalPrice();

            Assert.Equal(1.80m, result);
        }

        [Fact]
        public void GetBasketTotalWithMultipleOffers()
        {
            Dictionary<string, Item> items = new Dictionary<string, Item>()
            {
                {"A99", new Item{SKU = "A99", Price = 0.50m} },
                {"B15", new Item{SKU = "B15", Price = 0.30m} },
            };

            List<SpecialOffer> specialOffers = new List<SpecialOffer>()
            {
                new SpecialOffer(){SKU = "A99", Quantity = 3, Price = 1.30m },
                new SpecialOffer(){SKU = "B15", Quantity = 2, Price = 0.45m },
            };

            ItemLookup itemLookup = new ItemLookup(items);
            SpecialOfferLookup specialOfferLookup = new SpecialOfferLookup(specialOffers);

            Checkout checkout = new Checkout(itemLookup, specialOfferLookup);

            _ = checkout.AddItemToBasket("A99");
            _ = checkout.AddItemToBasket("A99");
            _ = checkout.AddItemToBasket("A99");
            _ = checkout.AddItemToBasket("B15");
            _ = checkout.AddItemToBasket("B15");

            var result = checkout.GetTotalPrice();

            Assert.Equal(1.75m, result);
        }
    }
}
