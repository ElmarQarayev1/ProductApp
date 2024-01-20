using System;
using static System.Reflection.Metadata.BlobBuilder;

namespace ProductApp
{
    public class Market : IStore
    {
       
        private double _totalIncome;
        public double TotalIncome => _totalIncome; 

        public int ProductLimit { get; }

        private Product[] _products;
       
        public Product[] Products => _products;

        public Market(int productLimit)
        {
            ProductLimit = productLimit;
            _products = new Product[0]; 
        }

        public void AddProduct( Product product)
        {
            Array.Resize(ref _products, _products.Length + 1);
            _products[_products.Length - 1] = product;   
            
        }

        public int count = 0;

        public void SellProduct(string name)
        {
            if (_products.Length == 0)
            {
                Console.WriteLine("depo hal hazirda bosdur");
            }
         
                for (int i = 0; i < _products.Length; i++)
                {
                    if (_products[i] != null && _products[i].Name == name && _products[i].Count > 0)
                    {
                        _products[i].Count -= 1;
                        count = _products[i].Count;
                        _totalIncome += _products[i].Price;
                    }
                    else
                    {
                        Console.WriteLine("ele adli product yoxdur");
                        break;
                    }
            }
        }
           
        public void ShowProducts()
        {
            Console.WriteLine("Productlar:");

            for (int i = 0; i < _products.Length; i++)
            {
                Console.WriteLine($"adi:{_products[i].Name} qiymeti:{_products[i].Price} sayi:{_products[i].Count}");
            }
        }
        public bool CheckName(string name)
        {
           
            for (int i = 0; i < _products.Length; i++)
            {

                if (_products[i].Name == name)
                {
                    return true;
                }
            }
            return false;

        }
        public bool CheckLimit(int count)
        {
            if (count >= ProductLimit)
            {
                return true;
            }
            return false;

        }


    }

}

