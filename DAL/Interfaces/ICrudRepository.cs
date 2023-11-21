using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ICrudRepository<TKey, TEntity>
    {

        TEntity? GetById(TKey id);

        IEnumerable<TEntity> GetAll();

        TEntity? Create(TEntity entity);

        bool Delete(TKey id);

        bool Update(TEntity entity);

    }
}
