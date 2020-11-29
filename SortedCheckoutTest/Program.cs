using SortedCheckoutTest.Logic;
using SortedCheckoutTest.Logic.Models;
using System;
using System.Collections.Generic;

namespace SortedCheckoutTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Item> itemDictionary = new Dictionary<string, Item>()
            {
                {"A99", new Item(){SKU = "A99",Price = 0.50m } },
                {"B15", new Item(){SKU = "B15",Price = 0.30m } },
                {"C40", new Item(){SKU = "C40",Price = 0.60m } },
            };

            List<SpecialOffer> specialOffers = new List<SpecialOffer>()
            {
                new SpecialOffer(){SKU = "A99", Quantity = 3, Price = 1.30m },
                new SpecialOffer(){SKU = "B15", Quantity = 2, Price = 0.45m },
            };

            IItemLookup itemLookup = new ItemLookup(itemDictionary);
            SpecialOfferLookup specialOfferLookup = new SpecialOfferLookup(specialOffers);

            ICheckout checkout = new Checkout(itemLookup, specialOfferLookup);

            Console.WriteLine("Please scan your items or ** to calculate price");

            while (true)
            {
                Console.Write("Please enter selection: ");
                var enteredText = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(enteredText))
                {
                    Console.WriteLine("Empty strings are unsupported, please try again");
                    continue;
                }

                try
                {
                    switch (enteredText)
                    {
                        case "**":
                            Console.WriteLine($"The current total is: {checkout.GetTotalPrice()}");
                            break;
                        default:
                            if (checkout.AddItemToBasket(enteredText) == false)
                            {
                                Console.WriteLine("Unable to find SKU");
                            }
                            break;
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Error when performing operation.");
                    Console.WriteLine(ex);
                }

            }
        }
    }
}
