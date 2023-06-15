namespace Solid.InterfaceSegregation.Bad
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public interface IProductRepository
    {
        List<Product> GetAll();
        Product GetById(int id);
        Product Add(Product product);
        Product Update(Product product);
        Product Delete(Product product);
        Product DeleteById(int id);
    }

    public class EfRepository : IProductRepository
    {
        public Product Add(Product product)
        {
            throw new NotImplementedException();
        }

        public Product Delete(Product product)
        {
            throw new NotImplementedException();
        }

        public Product DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            throw new NotImplementedException();
        }

        public Product GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Product Update(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
