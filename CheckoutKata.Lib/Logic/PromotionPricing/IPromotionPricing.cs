using CheckoutKata.Lib.Model;

namespace CheckoutKata.Lib.Logic.PromotionPricing
{
    public interface IPromotionPricing
    {
        float GetPromotionalPrice(Promotion promotion);
    }
}
