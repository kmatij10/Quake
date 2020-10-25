using System;
using System.Collections.Generic;
using System.Text;

namespace Quake.Core.Repositories
{
    public interface IRepository<T>
    {
        T GetOne(long id);

        IEnumerable<T> GetAll(string search);

        bool Delete(long id);

        T Create(T entity);

        T Update(long id, T entity);
    }
}
