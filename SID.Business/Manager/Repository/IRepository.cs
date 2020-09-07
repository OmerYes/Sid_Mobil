using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SID.Business.Manager.Repository
{
   public interface IRepository<T>
    {
        T Add(T entity);
        List<T> GetAll();
        void Update(T entity);
        bool Remove(int id);
        T Find(int id);
        T FirstOrDefault(Expression<Func<T, bool>> lambda);
        T FirstOrDefaultAll(Expression<Func<T, bool>> lambda);
        IQueryable<T> GetAllQuerableWithQuery(Expression<Func<T, bool>> exp);
        bool Any(Expression<Func<T, bool>> exp);
        List<T> GetByID(Expression<Func<T, bool>> exp);
        IQueryable<T> GetAllQuery();
        T Delete(int id);



    }
}
