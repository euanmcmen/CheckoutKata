using CheckoutKata.Lib.Logic.PromotionPricing;
using CheckoutKata.Lib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CheckoutKata.Lib.Repository
{
    public class CheckoutRepository
    {
        private readonly Dictionary<string, Item> items;
        private readonly List<Promotion> promotions;
        private readonly PromotionPricingMap defaultPromotionPricingMapping;

        public CheckoutRepository()
        {
            items = new Dictionary<string, Item>()
            {
                {"A",  new Item("A", 10) },
                {"B", new Item("B", 15) },
                {"C", new Item("C", 40) },
                {"D",  new Item("D", 55) },
            };

            promotions = new List<Promotion>()
            {
                new XForYPromotion() { Item = items["B"], QuantityForEffect = 3, BundlePrice = 40 },
                new PercentDiscountPromotion() {Item = items["D"], QuantityForEffect = 2, PercentDiscount = 25}
            };

            defaultPromotionPricingMapping = new PromotionPricingMap(new Dictionary<Type, IPromotionPricing>()
            {
                { typeof(XForYPromotion), new XForYPromotionPricing() },
                { typeof(PercentDiscountPromotion), new PercentDiscountPromotionPricing() }
            });
        }

        public List<Promotion> GetPromotionsForItemSKU(string sku)
        {
            return promotions.Where(x => x.Item.SKU == sku).ToList();
        }

        public PromotionPricingMap GetDefaultPromotionPricingMapping()
        {
            return defaultPromotionPricingMapping;
        }
    }
}
