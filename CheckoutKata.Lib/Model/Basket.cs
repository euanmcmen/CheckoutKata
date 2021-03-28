using System;
using System.Linq;
using System.Collections.Generic;

namespace CheckoutKata.Lib.Model
{
    public class Basket
    {
        public List<Item> Items { get; private set; }

        public Basket()
        {
            Items = new List<Item>();
        }
    }
}
