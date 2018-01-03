using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workloud.Challenge.Abstractions
{
    public interface ICommand<TEntity>
    {
        Task Create(TEntity entity);

        Task Update(TEntity entity);

        Task Delete(TEntity entity);
    }

}
