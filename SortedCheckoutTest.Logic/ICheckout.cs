using System;
using System.Collections.Generic;
using System.Text;

namespace SortedCheckoutTest.Logic
{
    public interface ICheckout
    {
        bool AddItemToBasket(string SKU);
    }
}
