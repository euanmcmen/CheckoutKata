using System;
using System.Collections.Generic;
using System.Text;

namespace CheckoutKata.Lib.Model
{
    public class Item
    {
        public string SKU { get; private set; }

        public float UnitPrice { get; private set; }

        public Item(string sku, float unitPrice)
        {
            SKU = sku;
            UnitPrice = unitPrice;
        }
    }
}
