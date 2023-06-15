namespace Solid.DependencyInversion.Good
{
    public class ProductService
    {
        private readonly IRepository _repository;

        public ProductService(IRepository repository)
        {
            _repository = repository;
        }

        public List<string> GetAll()
        {
            return _repository.GetAll();
        }
    }

    public class ProductRepoFromSqlServer : IRepository
    {
        public List<string> GetAll()
        {
            return new List<string>() { "SQL Ürün1", "SQL Ürün2" };
        }
    }

    public class ProductRepoFromOracle : IRepository
    {
        public List<string> GetAll()
        {
            return new List<string>() { "ORacle Ürün1", "ORacle Ürün2" };
        }
    }

    public interface IRepository
    {
        List<string> GetAll();
    }
}
