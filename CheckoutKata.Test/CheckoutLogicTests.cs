using CheckoutKata.Lib.Logic;
using CheckoutKata.Lib.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CheckoutKata.Test
{
    [TestClass]
    public class CheckoutLogicTests
    {
        CheckoutLogic checkoutLogic;

        [TestInitialize]
        public void Initialise()
        {
            checkoutLogic = new CheckoutLogic();
        }

        [TestMethod]
        public void WhenItemAddedToBasket_ThenItemAddedToBasket()
        {
            var itemA = new Item("A", 10);

            checkoutLogic.AddItem(itemA);

            Assert.AreEqual(1, checkoutLogic.BasketItems.Count);
        }
    }
}
