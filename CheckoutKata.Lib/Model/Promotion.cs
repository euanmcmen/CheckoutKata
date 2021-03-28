namespace CheckoutKata.Lib.Model
{
    public abstract class Promotion
    {
        public Item Item { get; set; }

        public int QuantityForEffect { get; set; }

        public abstract float GetPromotionPrice();
    }

    public class XForYPromotion : Promotion
    {
        public int BundlePrice { get; set; }

        public override float GetPromotionPrice() => BundlePrice;
    }

    public class PercentDiscountPromotion : Promotion
    {
        public int PercentDiscount { get; set; }

        public override float GetPromotionPrice()
        {
            var noDiscount = Item.UnitPrice * QuantityForEffect;
            var deduction = noDiscount * ((float)PercentDiscount / 100);
            return noDiscount - deduction;
        }
    }
}
