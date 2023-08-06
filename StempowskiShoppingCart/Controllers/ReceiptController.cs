using StempowskiShoppingCart.Interfaces;
using StempowskiShoppingCart.Models;

namespace StempowskiShoppingCart.Controllers
{
    public class ReceiptController : IReceiptController
    {
        public ReceiptController() { }

        public Receipt GenerateReceipt(List<MerchandiseItem> shoppingCart)
        {
            var receipt = new Receipt();

            foreach (var item in shoppingCart)
            {
                receipt.MerchandiseItems.Add(item);
                receipt.SubTotal = receipt.SubTotal + item.Price * item.Quantity;

                if (item.IsTaxExempt)
                {
                    receipt.SalesTax = receipt.SalesTax + 0;
                }
                else
                {
                    receipt.SalesTax = receipt.SalesTax + item.Price * item.Quantity * (decimal).1;
                }

                if (item.IsImported)
                {
                    receipt.SalesTax = receipt.SalesTax + item.Price * item.Quantity * (decimal).05;
                }
            }

            // rouding sales tax here up to nearest 5 cents
            receipt.SalesTax = Math.Ceiling(receipt.SalesTax * 20) / 20;

            receipt.GrandTotal = receipt.SubTotal + receipt.SalesTax;

            return receipt;
        }

        public bool ShopWithMe(string? clientInput)
        {
            var goShopping = true;

            while (goShopping)
            {
                var clentYesNoInput = clientInput;

                if (string.IsNullOrEmpty(clentYesNoInput) || clentYesNoInput.ToLower() != "yes" && clentYesNoInput.ToLower() != "no")
                {
                    Console.WriteLine("Hmm... I don't understand what you are trying here. Please type yes or no.");
                    clientInput = Console.ReadLine();
                    continue;
                }

                if (clentYesNoInput.ToLower() == "no")
                {
                    goShopping = false;
                    Console.WriteLine("Thank you. Have a nice Day. Press ENTER to cash out.");
                }
                else
                {
                    break;
                }
            }
            return goShopping;
        }

        public MerchandiseItem FillTheShoppingCart()
        {
            MerchandiseItem merchandiseItem = new MerchandiseItem();

            Console.WriteLine("What is the name of the item you want to buy? If you don't put a name in here it's ok. I'll just call it a Mystery Item.");
            merchandiseItem.ItemName = validateStrings(Console.ReadLine());
            Console.Clear();

            Console.WriteLine("Great! How much does that item cost. Check the price tag");
            merchandiseItem.Price = ValidatePrice(Console.ReadLine());
            Console.Clear();

            merchandiseItem.IsTaxExempt = ValidateNoTax(merchandiseItem.ItemName);
            
            if (merchandiseItem.ItemName.ToLower().Contains("import"))
            {
                merchandiseItem.IsImported = true;
            }

            if(!merchandiseItem.IsTaxExempt) 
            {
                Console.WriteLine("Is this a book, medicine or food?..... This kind of smells medical if I am being honest. Please Answer yes or no.");
                merchandiseItem.IsTaxExempt = IsThisTaxExempt(Console.ReadLine());
                Console.Clear();
            }

            if (!merchandiseItem.IsImported)
            {
                Console.WriteLine("Is imported? The language on the lable is in French. Please answer yes or no.");
                merchandiseItem.IsImported = IsThisImported(Console.ReadLine());
                Console.Clear();
            }

            Console.WriteLine("Awesome! How many of these things do you want?");
            merchandiseItem.Quantity = validateQuantity(Console.ReadLine());
            Console.Clear();

            return merchandiseItem;
        }
        public bool ValidateNoTax(string clientInput)
        {
            var merch = clientInput.ToLower();

            if (merch.Contains("book")
                || merch.Contains("food")
                || merch.Contains("medical")
                || merch.Contains("drug")
                || merch.Contains("medicine"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string validateStrings(string? response)
        {
            if (string.IsNullOrEmpty(response))
            {
                response = "Mystery Item";
            }

            return response;
        }

        public int validateQuantity(string? clientInput)
        {
            bool validateQuantity = true;
            int quantity = 0;

            while (validateQuantity)
            {
                if (!int.TryParse(clientInput, out quantity))
                {
                    Console.WriteLine("That isnt a number. Please try a whole number. If it isn't a whole number, I'm going to keep asking for one!");
                    clientInput = Console.ReadLine();
                    Console.Clear();
                }
                else
                {
                    validateQuantity = false;
                    quantity = int.Parse(clientInput);
                }
            }

            return quantity;
        }

        public decimal ValidatePrice(string? clientInput)
        {
            bool validateQuantity = true;
            decimal price = 0;

            while (validateQuantity)
            {
                if (!decimal.TryParse(clientInput, out price))
                {
                    Console.WriteLine("That isnt a number. Please use numbers.");
                    clientInput = Console.ReadLine();
                }
                else
                {
                    validateQuantity = false;
                    price = decimal.Parse(clientInput);
                }
            }

            return price;
        }

        public bool IsThisTaxExempt(string? clientInput)
        {
            bool validateBook = true;
            bool isThisABook = false;

            while (validateBook)
            {
                if (string.IsNullOrEmpty(clientInput) || clientInput.ToLower() != "yes" && clientInput.ToLower() != "no")
                {
                    Console.Clear();
                    Console.WriteLine("Hmm... I don't understand what you are trying here. Please type yes or no. So is this a book, food or medical?");
                    clientInput = Console.ReadLine();
                    continue;
                }

                if (clientInput.ToLower() == "no")
                {
                    validateBook = false;
                    isThisABook = false;
                }
                else
                {
                    validateBook = false;
                    isThisABook = true;
                }
            }

            return isThisABook;
        }

        public bool IsThisImported(string? clientInput)
        {
            bool validateImport = true;
            bool isImported = false;

            while (validateImport)
            {
                if (string.IsNullOrEmpty(clientInput) || clientInput.ToLower() != "yes" && clientInput.ToLower() != "no")
                {
                    Console.Clear();
                    Console.WriteLine("Hmm... I don't understand what you are trying here. Please type yes or no. So is this imported?");
                    clientInput = Console.ReadLine();
                    continue;
                }

                if (clientInput.ToLower() == "no")
                {
                    validateImport = false;
                    isImported = false;
                }
                else
                {
                    validateImport = false;
                    isImported = true;
                }
            }

            return isImported;
        }
    }
}
