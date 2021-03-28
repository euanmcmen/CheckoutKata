using CheckoutKata.Lib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CheckoutKata.Lib.Repository
{
    public class CheckoutRepository
    {
        public Dictionary<string, Item> Items { get; private set; }

        public List<Promotion> Promotions { get; private set; }

        public CheckoutRepository()
        {
            Items = new Dictionary<string, Item>()
            {
                {"A",  new Item("A", 10) },
                {"B", new Item("B", 15) },
                {"C", new Item("C", 40) },
                {"D",  new Item("D", 55) },
            };

            Promotions = new List<Promotion>()
            {
                new XForYPromotion() { Item = Items["B"], QuantityForEffect = 3, BundlePrice = 40 },
                new PercentDiscountPromotion() {Item = Items["D"], QuantityForEffect = 2, PercentDiscount = 25}
            };
        }

        public List<Promotion> GetPromotionsForItemSKU(string sku)
        {
            return Promotions.Where(x => x.Item.SKU == sku).ToList();
        }
    }
}
