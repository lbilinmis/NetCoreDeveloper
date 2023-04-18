using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.SingleResponsibility.Bad
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }

        private static List<Product> productList = new List<Product>();

        public List<Product> GetPRoducts => productList;

        public Product()
        {
            productList = new()
            {
                new Product {Id=1,Name="Kalem 1"},
                new Product {Id=2,Name="Kalem 2"},
                new Product {Id=3,Name="Kalem 3"},
                new Product {Id=4,Name="Kalem 4"},
            };
        }

        public void SaveOrUpdate(Product product)
        {
            var hasProduct = productList.Any(x => x.Id == product.Id);

            if (!hasProduct)
            {
                productList.Add(product);
            }
            else
            {
                var index = productList.FindIndex(x => x.Id == product.Id);

                productList[index] = product;
            }
        }

        public void Delete(int id)
        {
            var hasProduct = productList.SingleOrDefault(x => x.Id == id);

            if (hasProduct == null)
            {
                throw new Exception("Ürün bulunamadı");
            }
            productList.Remove(hasProduct);

        }

        public void WriteTConsole()
        {
            productList.ForEach(x =>
            {
                Console.WriteLine($"{x.Id} - {x.Name}");
            });
        }
    }
}
