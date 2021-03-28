using CheckoutKata.Lib.Model;
using System.Collections.Generic;
using System.Linq;

namespace CheckoutKata.Lib.Logic
{
    public class CheckoutLogic
    {
        private readonly Basket basket;

        public List<Item> BasketItems => basket.Items;

        public CheckoutLogic()
        {
            basket = new Basket();
        }

        public void AddItemToBasket(Item item, int quantity)
        {
            for (int i = 0; i < quantity; i++)
            {
                basket.Items.Add(item);
            }
        }

        public float GetBasketTotalCost()
        {
            return basket.Items.Sum(x => x.UnitPrice);
        }
    }
}
