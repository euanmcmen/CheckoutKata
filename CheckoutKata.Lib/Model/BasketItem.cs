using System;
using System.Collections.Generic;
using System.Text;

namespace CheckoutKata.Lib.Model
{
    public class BasketItem
    {
        public Item Item { get; set; }

        public int Quantity { get; set; }

        public BasketItem(Item item, int quantity)
        {
            Item = item;
            Quantity = quantity;
        }
    }
}
