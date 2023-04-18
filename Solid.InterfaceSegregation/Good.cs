using Solid.InterfaceSegregation.Bad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.InterfaceSegregation.Good
{
    public class T
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public interface IProductRepository<T> : IWriteRepository<Good.T>, IReadRepository<Good.T>
    {

    }

    public interface IWriteRepository<T> where T : class, new()
    {
        T Add(T entity);
        T Update(T entity);
        T Delete(T entity);
        T DeleteById(int id);
    }

    public interface IReadRepository<T> where T : class, new()
    {
        List<T> GetAll();
        T GetById(int id);

    }

    public class EfAllRepository : IProductRepository<T>
    {
        public T Add(T entity)
        {
            throw new NotImplementedException();
        }

        public T Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public T DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public List<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public T GetById(int id)
        {
            throw new NotImplementedException();
        }

        public T Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
    public class EfWriteRepository : IWriteRepository<T>
    {
        public T Add(T entity)
        {
            throw new NotImplementedException();
        }

        public T Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public T DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public T Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
    public class EfReadRepository : IReadRepository<T>
    {
        public List<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public T GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
