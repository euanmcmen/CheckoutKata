using CheckoutKata.Lib.Logic;
using CheckoutKata.Lib.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CheckoutKata.Test
{
    [TestClass]
    public class CheckoutLogicTests
    {
        CheckoutLogic checkoutLogic;

        readonly Item itemA;
        readonly Item itemB;
        readonly Item itemC;
        readonly Item itemD;

        public CheckoutLogicTests()
        {
            itemA = new Item("A", 10);
            itemB = new Item("B", 15);
            itemC = new Item("C", 40);
            itemD = new Item("D", 55);
        }

        [TestInitialize]
        public void Initialise()
        {
            checkoutLogic = new CheckoutLogic();
        }

        [TestMethod]
        public void WhenItemAddedToBasket_ThenItemAddedToBasket()
        {
            checkoutLogic.AddItemToBasket(itemA, 1);

            Assert.AreEqual(1, checkoutLogic.BasketItems.Count);
        }

        [TestMethod]
        public void GetTotalCost_CalculatesCostOfAllItems()
        {
            checkoutLogic.AddItemToBasket(itemA, 3);
            checkoutLogic.AddItemToBasket(itemB, 1);

            Assert.AreEqual(45, checkoutLogic.GetBasketTotalCost());
        }
    }
}
