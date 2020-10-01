using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace SnackPros.DataAccess.Data.Repository.IRepository
{
    public interface IRepository<T> where T : class // Generic class T 
    {
        // Methods usded accross all repositories: Get, GetAll, GetFirstOrDefault, Add, Remove id, Remove entity.

        T Get(int id);

        //Link operation for filtering to getall 
        IEnumerable<T> GetAll(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = null
            );

        T GetFirstOrDefault(
            Expression<Func<T, bool>> filter = null,
            string includeProperties = null
            );

        void Add(T entity);
        void Remove(int id);
        void Remove(T entity);
    }
}
