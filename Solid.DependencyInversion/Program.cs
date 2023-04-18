// See https://aka.ms/new-console-template for more information


//using Solid.DependencyInversion.Bad;

//ProductService productService = new ProductService(new ProductRepoFromSqlServer());

//productService.GetAll().ForEach(x => Console.WriteLine(x));


using Solid.DependencyInversion.Good;

ProductService productService = new ProductService(new ProductRepoFromOracle());

productService.GetAll().ForEach(x => Console.WriteLine(x));

