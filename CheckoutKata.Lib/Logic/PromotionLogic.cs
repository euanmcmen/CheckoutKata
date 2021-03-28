using CheckoutKata.Lib.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CheckoutKata.Lib.Logic
{
    public class PromotionCalculationResult
    {
        public int ItemsProcessed { get; set; }

        public float TotalCost { get; set; }
    }

    public class PromotionLogic
    {
        public PromotionCalculationResult GetBasketItemPromotionCost(BasketItem basketItem, Promotion promotion)
        {
            var numberOfApplications = Math.DivRem(basketItem.Quantity, promotion.QuantityForEffect, out _);

            var total = GetItemPromotionalPrice(basketItem.Item, promotion) * numberOfApplications;
            var itemsProcessed = promotion.QuantityForEffect * numberOfApplications;

            return new PromotionCalculationResult()
            {
                TotalCost = total,
                ItemsProcessed = itemsProcessed,
            };
        }

        private float GetItemPromotionalPrice(Item item, Promotion promotion)
        {
            //TODO - strategy

            if (promotion is XForYPromotion xyPromo)
            {
                return xyPromo.BundlePrice;
            }

            if (promotion is PercentDiscountPromotion perPromo)
            {
                var noDiscount = item.UnitPrice * perPromo.QuantityForEffect;
                var deduction = noDiscount * ((float)perPromo.PercentDiscount / 100);
                return noDiscount - deduction;
            }

            return item.UnitPrice;
        }
    }
}
