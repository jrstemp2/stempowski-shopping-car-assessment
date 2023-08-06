using StempowskiShoppingCart.Models;

namespace StempowskiShoppingCart.Interfaces
{
    public interface IReceiptController
    {
        public Receipt GenerateReceipt(List<MerchandiseItem> shoppingCart);
        public bool ShopWithMe(string? clientInput);

        public MerchandiseItem FillTheShoppingCart();
        public bool ValidateNoTax(string clientInput);
        public string validateStrings(string? response);

        public int validateQuantity(string? clientInput);

        public decimal ValidatePrice(string? clientInput);

        public bool IsThisTaxExempt(string? clientInput);
        public bool IsThisImported(string? clientInput);
    }
}
