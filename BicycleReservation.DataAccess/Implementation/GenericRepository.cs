using BicycleReservation.DataAccess.Context;
using BicycleReservation.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BicycleReservation.DataAccess.Implementation
{
    public class GenericRepository<T, G> : IGenericRepository<T, G> where T : class
    {
        public DataContext context { get; set; }
        public GenericRepository(DataContext context)
        {
            this.context = context;
        }
        //public void Add(T entity)
        //{
        //    throw new NotImplementedException();
        //}

        //public void AddRange(IEnumerable<T> entities)
        //{
        //    throw new NotImplementedException();
        //}

        public void Delete(T entity)
        {
            context.Set<T>().Remove(entity);
        }

        //public void DeleteRange(IEnumerable<T> entities)
        //{
        //    throw new NotImplementedException();
        //}

        //public IEnumerable<T> FindAll(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        //{
        //    throw new NotImplementedException();
        //}

        //public IEnumerable<T> GetAll()
        //{
        //    throw new NotImplementedException();
        //}

        public T GetById(G id)
        {
            return context.Set<T>().Find(id);
        }

        public void Update(T entity)
        {
            context.Set<T>().Update(entity);
        }
    }
}
