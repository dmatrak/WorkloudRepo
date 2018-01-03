using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Workloud.Challenge.Abstractions
{
    public interface IQuery<TEntity>
    {
        Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity> GetAsync(int id);

        Task<IEnumerable<TEntity>> GetAllAsync();
    }
}
