namespace ProductApp;

class Program
{
    static void Main(string[] args)
    {
        //Console.ForegroundColor = ConsoleColor.White;
        //Console.BackgroundColor = ConsoleColor.DarkGreen;
        //Console.Clear();
        const int limit = 100;
        string secim;
        Market market = new Market(limit);
        do
        {
            ShowMainMenu();
            secim = Console.ReadLine();
            switch (secim)
            {
                case "1":
                    AddProduct(market);
                    break;
                case "2":
                    market.ShowProducts();
                    SellProducts(market);
                    break;
                case "3":
                   market.ShowProducts();
                    break;
                case "4":
                    Console.WriteLine("proqramdan cixildi");
                    break;
                default:
                    Console.WriteLine("secim yanlisdir!");
                    break;
            }

        } while (secim!="4");

        Console.ReadLine();
    }
    static void ShowMainMenu()
    {
        Console.WriteLine("1.Product elave et:");
        Console.WriteLine("2.Product Sat:");
        Console.WriteLine("3.Productlara bax:");
        Console.WriteLine("4.Menudan cix");
        Console.WriteLine("secim :");
    }
   
    static void SellProducts(Market market)
    {
  
        string name1;
        do
        {
            Console.WriteLine("satmaq istediyiniz productun adini daxil edin;");
            name1 = Console.ReadLine();

        } while (String.IsNullOrWhiteSpace(name1));

        market.SellProduct(name1);
        Console.WriteLine($"toplam qazanc-{market.TotalIncome}");
        Console.WriteLine($"say -{market.count}");
    }
    static void AddProduct(Market market)
    {
    
            
            string name;
            do
            {
                   Console.WriteLine("Productun adini daxil edin:");
                   name = Console.ReadLine();

            } while (String.IsNullOrWhiteSpace(name));
            if (market.CheckName(name))
            {
            Console.WriteLine("eyni adli product daxil edile bilmez");
            }
            else
            {
            string Strprice;
            double price;
            do
            {
                Console.WriteLine("productun qiymetini daxil edin:");
                Strprice = Console.ReadLine();

            } while (!double.TryParse(Strprice, out price) || price < 0);
            string Strcount;
            int count;
            do
            {
                Console.WriteLine("productun sayini daxil edin:");
                Strcount = Console.ReadLine();

            } while (!int.TryParse(Strcount, out count) || count < 0);

            if (market.CheckLimit(count))
            {
                Console.WriteLine("siz limiti kecmisiniz!");
            }
            else
            {
                Product newProduct = new Product { Name = name, Price = price, Count = count };

                market.AddProduct(newProduct);

            }

           
           }
            
    }
}



