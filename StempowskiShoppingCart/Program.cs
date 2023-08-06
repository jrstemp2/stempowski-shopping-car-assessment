using StempowskiShoppingCart.Controllers;
using StempowskiShoppingCart.Models;

// Everything below this line is a method that is used in this program.
// I am also calling methods from the Receipt Controller to generate the receipt.
ReceiptController controller = new ReceiptController();
List<MerchandiseItem> shoppingCart = new List<MerchandiseItem>();
var goShopping = true;
Console.WriteLine("Welcome to John-Mart! Would you like to shop?");

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
        string displayString = "";

        Console.ReadLine();
        Console.WriteLine("I Wonder.....");
        Console.WriteLine("Will I....Dream??");
        Console.WriteLine();
        Console.WriteLine("Please Press ENTER to see your Receipt.");
        Console.ReadLine();
        Console.Clear();

        Console.WriteLine("_______________________________");
        Console.WriteLine("JOHN-MART: YOUR GO TO PLACE FOR LIFE");
        Console.WriteLine($"Receipt For {receipt.ReceiptDate}");
        Console.WriteLine("_______________________________");

        foreach(var item in receipt.MerchandiseItems)
        {
            if (item.Quantity > 1)
            {
                displayString = $"{item.ItemName}: ${item.Price * item.Quantity} ({item.Quantity} @ ${item.Price.ToString("F")})";
            }
            else
            {
                displayString = $"{item.ItemName}: ${item.Price.ToString("F")}";
            }

            if (item.IsImported)
            {
                displayString = "Imported " + displayString;
            }

            Console.WriteLine(displayString);
        }

        Console.WriteLine("_______________________________");
        Console.WriteLine($"Sub Total: ${receipt.SubTotal.ToString("F")}");
        Console.WriteLine($"Sales Tax: ${receipt.SalesTax.ToString("F")}");
        Console.WriteLine($"Grand Total: ${receipt.GrandTotal.ToString("F")}");
        Console.WriteLine("_______________________________");
    }

}
