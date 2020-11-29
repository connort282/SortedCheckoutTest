using SortedCheckoutTest.Logic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SortedCheckoutTest.Logic
{
    public interface IItemLookup
    {
        Item GetItem(string SKU);
    }
}
