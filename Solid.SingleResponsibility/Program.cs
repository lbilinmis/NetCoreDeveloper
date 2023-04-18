// See https://aka.ms/new-console-template for more information
using Solid.SingleResponsibility.Good;

Console.WriteLine("Hello, World!");

ProductRepository productRepository = new ProductRepository();
productRepository.GetAllList().ForEach(x =>
{
    Console.WriteLine(x.Id);
});