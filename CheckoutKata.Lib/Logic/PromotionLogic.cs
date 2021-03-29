using CheckoutKata.Lib.Logic.PromotionPricing;
using CheckoutKata.Lib.Model;
using System;

namespace CheckoutKata.Lib.Logic
{
    public class PromotionCalculationResult
    {
        public int ItemsProcessed { get; set; }

        public float TotalCost { get; set; }
    }

    public class PromotionLogic
    {
        private readonly PromotionPricingMap promotionPricingMap;

        public PromotionLogic(PromotionPricingMap promotionPricingMap)
        {
            this.promotionPricingMap = promotionPricingMap;
        }

        public PromotionCalculationResult GetBasketItemPromotionCost(BasketItem basketItem, Promotion promotion)
        {
            var numberOfApplications = Math.DivRem(basketItem.Quantity, promotion.QuantityForEffect, out _);

            var total = GetPromotionalPrice(promotion) * numberOfApplications;
            var itemsProcessed = promotion.QuantityForEffect * numberOfApplications;

            return new PromotionCalculationResult()
            {
                TotalCost = total,
                ItemsProcessed = itemsProcessed,
            };
        }

        private float GetPromotionalPrice(Promotion promotion)
        {
            if (promotionPricingMap.Mapping.TryGetValue(promotion.GetType(), out IPromotionPricing promotionPricing))
                return promotionPricing.GetPromotionalPrice(promotion);

            throw new NotImplementedException($"No PromotionPricing implementation for Promotion type {promotion.GetType().Name} in PromotionPricingMap");
        }
    }
}
