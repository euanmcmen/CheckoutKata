using CheckoutKata.Lib.Model;

namespace CheckoutKata.Lib.Logic.PromotionPricing
{
    public class XForYPromotionPricing : IPromotionPricing
    {
        public float GetPromotionalPrice(Promotion promotion)
        {
            return (promotion as XForYPromotion).BundlePrice;
        }
    }
}
