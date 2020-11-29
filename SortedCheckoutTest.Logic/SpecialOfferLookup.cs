using SortedCheckoutTest.Logic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SortedCheckoutTest.Logic
{
    public class SpecialOfferLookup : ISpecialOfferLookup
    {
        private IList<SpecialOffer> _specialOffers;
        public SpecialOfferLookup(IList<SpecialOffer> specialOffers)
        {
            _specialOffers = specialOffers;
        }

        public IList<SpecialOffer> GetSpecialOffers()
        {
            return _specialOffers;
        }
    }
}
