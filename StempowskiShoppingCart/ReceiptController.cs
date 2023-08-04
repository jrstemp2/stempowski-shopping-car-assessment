namespace StempowskiShoppingCart
{
    public class ReceiptController
    {
        public ReceiptController() { }

        public Receipt GenerateReceipt(List<MerchandiseItem> shoppingCart)
        {
            var receipt = new Receipt();

            foreach (var item in shoppingCart)
            {
                receipt.MerchandiseItems.Add(item);
                receipt.SubTotal = receipt.SubTotal + (item.Price * item.Quantity);
                
                if (item.IsBook)
                {
                    receipt.SalesTax = receipt.SalesTax + (item.Price * item.Quantity * (decimal).05);
                }
                else
                {
                    receipt.SalesTax = receipt.SalesTax + (item.Price * item.Quantity * (decimal).1);
                }
            }

            receipt.GrandTotal = receipt.SubTotal + receipt.SalesTax;

            return receipt;
        }

        public bool ShopWithMe(string? clientInput)
        {
            var goShopping = true;

            while (goShopping)
            {
                var clentYesNoInput = clientInput;

                if (string.IsNullOrEmpty(clentYesNoInput) || (clentYesNoInput.ToLower() != "yes" && clentYesNoInput.ToLower() != "no"))
                {
                    Console.WriteLine("Hmm... I don't understand what you are trying here. Please type yes or no. Developers don't like Nulls and Empty Strings much.");
                    clientInput = Console.ReadLine();
                    continue;
                }

                if (clentYesNoInput.ToLower() == "no")
                {
                    goShopping = false;
                    Console.WriteLine("Thank you. Have a nice Day. Press ENTER to end program.");
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

            Console.WriteLine("What is the name of the item you want to buy?");
            merchandiseItem.ItemName = validateStrings(Console.ReadLine());

            Console.WriteLine("Great! How much does that item cost. Check the price tag");
            merchandiseItem.Price = ValidatePrice(Console.ReadLine());

            if (merchandiseItem.ItemName.ToLower().Contains("book"))
            {
                merchandiseItem.IsBook = true;
            }
            else
            {
                Console.WriteLine("Is this a book? It smells like a musty book.");
                merchandiseItem.IsBook = IsThisABook(Console.ReadLine());
            }

            Console.WriteLine("Awesome! How many of these things do you want?");
            merchandiseItem.Quantity = validateQuantity(Console.ReadLine());

            return merchandiseItem;
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
                if (!Int32.TryParse(clientInput, out quantity))
                {
                    Console.WriteLine("That isnt a number. Please try a whole number");
                    clientInput = Console.ReadLine();
                }
                else
                {
                    validateQuantity = false;
                    quantity = Int32.Parse(clientInput);
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
                if (!Decimal.TryParse(clientInput, out price))
                {
                    Console.WriteLine("That isnt a number. Please use numbers.");
                    clientInput = Console.ReadLine();
                }
                else
                {
                    validateQuantity = false;
                    price = Decimal.Parse(clientInput);
                }
            }

            return price;
        }

        public bool IsThisABook(string? clientInput)
        {
            bool validateBook = true;
            bool isThisABook = false;

            while (validateBook)
            {
                if (string.IsNullOrEmpty(clientInput) || clientInput.ToLower() != "yes" && clientInput.ToLower() != "no")
                {
                    Console.Clear();
                    Console.WriteLine("Hmm... I don't understand what you are trying here. Please type yes or no. So is this a book?");
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
    }
}
