using SortedCheckoutTest.Logic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SortedCheckoutTest.Logic
{
    public interface ISpecialOfferLookup
    {
        IList<SpecialOffer> GetSpecialOffers();
    }
}
