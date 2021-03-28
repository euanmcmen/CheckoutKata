using CheckoutKata.Lib.Model;
using CheckoutKata.Lib.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CheckoutKata.Lib.Logic
{
    public class CheckoutLogic
    {
        private readonly CheckoutRepository checkoutRepository;
        private readonly PromotionLogic promotionLogic;

        private readonly Dictionary<string, BasketItem> basketItems;

        public CheckoutLogic()
        {
            checkoutRepository = new CheckoutRepository();
            promotionLogic = new PromotionLogic();
            basketItems = new Dictionary<string, BasketItem>();
        }

        public void AddItemToBasket(Item item, int quantity)
        {
            if (!basketItems.ContainsKey(item.SKU))
            {
                basketItems.Add(item.SKU, new BasketItem(item, 0));
            }

            basketItems[item.SKU].Quantity += quantity;
        }

        public int GetBasketQuantity()
        {
            return basketItems.Values.Sum(x => x.Quantity);
        }

        public float GetBasketTotalCost()
        {
            float totalCost = 0;

            foreach (var itemGroup in basketItems)
            {
                var totalOfGroup = GetBasketItemCost(itemGroup.Value);
                totalCost += totalOfGroup;
            }

            return totalCost;
        }

        private float GetBasketItemCost(BasketItem basketItem)
        {
            var promotionsForItem = checkoutRepository.GetPromotionsForItemSKU(basketItem.Item.SKU);

            var total = 0.0f;
            var quantityNotPromotional = basketItem.Quantity;

            foreach (var promotion in promotionsForItem)
            {
                var promotionResult = promotionLogic.GetBasketItemPromotionCost(basketItem, promotion);

                total += promotionResult.TotalCost;
                quantityNotPromotional -= promotionResult.ItemsProcessed;
            }

            total += basketItem.Item.UnitPrice * quantityNotPromotional;

            return total;
        }
    }
}
