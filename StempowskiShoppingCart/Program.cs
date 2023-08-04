using StempowskiShoppingCart;

// Everything below this line is a method that is used in this program.
// I am also calling methods from the Receipt Controller to generate the receipt.
ReceiptController controller = new ReceiptController();
List<MerchandiseItem> shoppingCart = new List<MerchandiseItem>();
var goShopping = true;
Console.WriteLine("Wanna Shop?");

while (goShopping)
{
    goShopping = controller.ShopWithMe(Console.ReadLine());
    break;
}
    
while (goShopping)
{
    var shoppingCartItem = controller.FillTheShoppingCart();
    shoppingCart.Add(shoppingCartItem);

    Console.WriteLine("Would you like to buy anything else?");

    goShopping = controller.ShopWithMe(Console.ReadLine());

    if (!goShopping && shoppingCart.Count > 0)
    {
        var receipt = controller.GenerateReceipt(shoppingCart);

        Console.WriteLine($"Receipt For {receipt.ReceiptDate}");
        Console.WriteLine("_______________________________");

        foreach(var item in receipt.MerchandiseItems)
        {
            Console.WriteLine($"{item.ItemName} ${item.Price.ToString("F")} @ {item.Quantity}");
        }

        Console.WriteLine("_______________________________");
        Console.WriteLine($"Sub Total: ${receipt.SubTotal.ToString("F")}");
        Console.WriteLine($"Sales Tax: ${receipt.SalesTax.ToString("F")}");
        Console.WriteLine($"Grand Total: ${receipt.GrandTotal.ToString("F")}");
    }

}
