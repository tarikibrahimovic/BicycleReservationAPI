using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BicycleReservation.Domain.Repository
{
    public interface IGenericRepository<T, G> where T : class
    {
        T GetById(G id);
        //IEnumerable<T> GetAll();
        //IEnumerable<T> FindAll(Expression<Func<T, bool>> predicate);
        //void Add(T entity);
        //void AddRange(IEnumerable<T> entities);
        void Update(T entity);
        void Delete(T entity);
        //void DeleteRange(IEnumerable<T> entities);
        //ovo su funkcije koje su zajednicke za sve repozitorijume ali ne moraju da postoje ako nisu potrebne

    }
}
