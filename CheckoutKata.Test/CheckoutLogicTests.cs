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

            Assert.AreEqual(1, checkoutLogic.GetBasketQuantity());
        }

        [TestMethod]
        public void GetTotalCost_CalculatesCostOfAllItems()
        {
            checkoutLogic.AddItemToBasket(itemA, 3);
            checkoutLogic.AddItemToBasket(itemB, 1);

            Assert.AreEqual(45, checkoutLogic.GetBasketTotalCost());
        }

        [TestMethod]
        public void When3ItemBAddedToBasket_Then3For40PromotionAndTotalCostIs40()
        {
            checkoutLogic.AddItemToBasket(itemB, 3);

            Assert.AreEqual(40, checkoutLogic.GetBasketTotalCost());
        }

        [TestMethod]
        public void When2ItemDAddedToBasket_Then25PercentOffPromotionAndTotalCostIs82Point5()
        {
            checkoutLogic.AddItemToBasket(itemD, 2);

            Assert.AreEqual(82.5, checkoutLogic.GetBasketTotalCost());
        }

        [TestMethod]
        public void When4ItemDAddedToBasket_Then25PercentOffPromotionAndTotalCostIs165Point5()
        {
            checkoutLogic.AddItemToBasket(itemD, 4);

            Assert.AreEqual(165, checkoutLogic.GetBasketTotalCost());
        }

        [TestMethod]
        public void WhenTwoPromosApply_BothUsedSeparately()
        {
            checkoutLogic.AddItemToBasket(itemA, 3);
            checkoutLogic.AddItemToBasket(itemB, 3);
            checkoutLogic.AddItemToBasket(itemC, 0);
            checkoutLogic.AddItemToBasket(itemD, 4);

            Assert.AreEqual(235, checkoutLogic.GetBasketTotalCost());
        }
    }
}
