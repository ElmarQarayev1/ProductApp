using System;
namespace ProductApp
{
    public interface IStore
	{
		public Product[] Products { get;  }

		public int ProductLimit { get; }

		public double TotalIncome { get; }

		public void  AddProduct(Product product);

		public  void SellProduct(string name);
   
    }
}

