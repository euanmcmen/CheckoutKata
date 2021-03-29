using System;
using System.Collections.Generic;
using System.Text;

namespace CheckoutKata.Lib.Logic.PromotionPricing
{
    public class PromotionPricingMap
    {
        public Dictionary<Type, IPromotionPricing> Mapping { get; private set; }

        public PromotionPricingMap(Dictionary<Type, IPromotionPricing> mapping)
        {
            this.Mapping = mapping;
        }
    }
}
