namespace CheckoutKata.Lib.Model
{
    public abstract class Promotion
    {
        public Item Item { get; set; }

        public int QuantityForEffect { get; set; }
    }

    public class XForYPromotion : Promotion
    {
        public int BundlePrice { get; set; }
    }

    public class PercentDiscountPromotion : Promotion
    {
        public int PercentDiscount { get; set; }
    }
}
