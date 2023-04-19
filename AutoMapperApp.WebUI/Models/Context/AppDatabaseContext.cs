using Microsoft.EntityFrameworkCore;

namespace AutoMapperApp.WebUI.Models.Context
{
    public class AppDatabaseContext : DbContext
    {
        //1.Yöntem
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data source=IGU-NB-0884;initial catalog=FluentValidationDb;user id=sa;password=s123456*-;");
            base.OnConfiguring(optionsBuilder);
        }

        //2.Yöntem

        //public AppDatabaseContext(DbContextOptions<AppDatabaseContext> options) : base(options)
        //{

        //}
        public DbSet<Customer> Customers { get; set; }
        public IList<Address> Addresses { get; set; }

    }

}
