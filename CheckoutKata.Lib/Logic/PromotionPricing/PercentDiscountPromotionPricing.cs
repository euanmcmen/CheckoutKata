using CheckoutKata.Lib.Model;

namespace CheckoutKata.Lib.Logic.PromotionPricing
{
    public class PercentDiscountPromotionPricing : IPromotionPricing
    {
        public float GetPromotionalPrice(Promotion promotion)
        {
            var perPromo = promotion as PercentDiscountPromotion;

            var noDiscount = perPromo.Item.UnitPrice * perPromo.QuantityForEffect;
            var deduction = noDiscount * ((float)perPromo.PercentDiscount / 100);
            return noDiscount - deduction;
        }
    }
}
