namespace Solid.SingleResponsibility.Good
{
    public class NewProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }

    public class ProductMethods
    {
        public void WriteTConsole(List<NewProduct> products)
        {
            products.ForEach(x =>
            {
                Console.WriteLine($"{x.Id} - {x.Name}");
            });
        }
    }

    public class ProductRepository
    {
        private static List<NewProduct> NewProductList = new List<NewProduct>();
        public List<NewProduct> GetAll => NewProductList;

        public ProductRepository()
        {
            NewProductList = new()
            {
                new NewProduct {Id=1,Name="Kalem 1"},
                new NewProduct {Id=2,Name="Kalem 2"},
                new NewProduct {Id=3,Name="Kalem 3"},
                new NewProduct {Id=4,Name="Kalem 4"},
            };

        }

        public void SaveOrUpdate(NewProduct NewProduct)
        {
            var hasNewProduct = NewProductList.Any(x => x.Id == NewProduct.Id);

            if (!hasNewProduct)
            {
                NewProductList.Add(NewProduct);
            }
            else
            {
                var index = NewProductList.FindIndex(x => x.Id == NewProduct.Id);

                NewProductList[index] = NewProduct;
            }
        }

        public void Delete(int id)
        {
            var hasNewProduct = NewProductList.SingleOrDefault(x => x.Id == id);

            if (hasNewProduct == null)
            {
                throw new Exception("Ürün bulunamadı");
            }
            NewProductList.Remove(hasNewProduct);

        }

        public List<NewProduct> GetAllList()
        {
            return ProductRepository.NewProductList;
        }
    }
}
