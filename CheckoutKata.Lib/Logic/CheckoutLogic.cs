using CheckoutKata.Lib.Model;
using System.Collections.Generic;

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

        public void AddItem(Item item)
        {
            basket.Items.Add(item);
        }
    }
}
