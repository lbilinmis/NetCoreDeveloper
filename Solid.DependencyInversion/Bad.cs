namespace Solid.DependencyInversion.Bad
{
    public class ProductService
    {
        private readonly ProductRepoFromSqlServer _productRepoFromSqlServer;

        public ProductService(ProductRepoFromSqlServer productRepoFromSqlServer)
        {
            _productRepoFromSqlServer = productRepoFromSqlServer;
        }

        public List<string> GetAll()
        {
            return _productRepoFromSqlServer.GetAll();
        }
    }

    public class ProductRepoFromSqlServer
    {
        public List<string> GetAll()
        {
            return new List<string>() { "SQL Ürün1", "SQL Ürün2" };
        }
    }

    public class ProductRepoFromOracle
    {
        public List<string> GetAll()
        {
            return new List<string>() { "ORacle Ürün1", "ORacle Ürün2" };
        }
    }
}
