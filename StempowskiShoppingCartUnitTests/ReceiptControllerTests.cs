using StempowskiShoppingCart.Controllers;
using StempowskiShoppingCart.Models;

namespace StempowskiShoppingCartUnitTests
{

    public class ReceiptControllerTests
    {
        ReceiptController _controller = new ReceiptController();

        List<MerchandiseItem> mockShoppingCart = new List<MerchandiseItem>()
        {
            new MerchandiseItem()
            {
                ItemName = "TestItem!",
                Price = (decimal)4.00,
                IsTaxExempt = false,
                IsImported = false,
                Quantity = 1,

            },
            new MerchandiseItem()
            {
                ItemName = "Cook Book",
                Price = (decimal)2.00,
                IsTaxExempt = true,
                IsImported = false,
                Quantity = 2,
            },
            new MerchandiseItem()
            {
                ItemName = "Cook Book",
                Price = (decimal)2.00,
                IsTaxExempt = false,
                IsImported = true,
                Quantity = 2,
            }
        };

        [Fact]
        public void GenerateReceipt_Should_ReturnValidReceipt_WhenItemIsComplete()
        {
            var result = _controller.GenerateReceipt(mockShoppingCart);

            Assert.NotNull(result);
            Assert.Equal(12, result.SubTotal);
            Assert.Equal((decimal)1.00, result.SalesTax);
            Assert.Equal((decimal)13.00, result.GrandTotal);
        }

        [Theory]
        [InlineData("yes", true)]
        [InlineData("no", false)]
        public void ShopWithMe_Should_ConvertYesNoToBool(string clientInput, bool expectedResult)
        {
            var result = _controller.ShopWithMe(clientInput);

            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData("game", "game")]
        [InlineData("book", "book")]
        [InlineData("", "Mystery Item")]
        [InlineData(null, "Mystery Item")]
        public void ValidateString_Should_ProvideCorrectName_BasedOnInput(string clientInput, string expectedResult)
        {
            var result = _controller.validateStrings(clientInput);

            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData("1", 1)]
        [InlineData("2", 2)]

        public void ValidateQuantity_Should_RetunInt(string clientInput, int expectedResult)
        {
            var result = _controller.validateQuantity(clientInput);

            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData("1", 1.00)]
        [InlineData("1.999", 1.999)]

        public void ValidatePrice_Should_ReturnDecimal(string clientInput, decimal expectedResult)
        {
            var result = _controller.ValidatePrice(clientInput);

            Assert.Equal(expectedResult, result);
        }

    }
}